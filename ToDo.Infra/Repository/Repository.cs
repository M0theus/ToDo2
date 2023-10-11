using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts;
using ToDo.Domain.Contracts.Paginacao;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Extensions;

namespace ToDo.Infra.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
   private bool _isDisposed;
    private readonly DbSet<TEntity> _dbSet;
    protected readonly ApplicationDbContext Context;

    public IUnitOfWork UnitOfWork => Context;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public virtual async Task<IResultadoPaginado<TEntity>> Buscar(IBuscaPaginada<TEntity> filtro)
    {
        var queryable = _dbSet.AsQueryable();
        
        filtro.AplicarFiltro(ref queryable);
        filtro.AplicarOrdenacao(ref queryable);
        
        return await queryable.BuscarPaginadoAsync(filtro.Pagina, filtro.TamanhoPagina);
    }
    
    public async Task<IResultadoPaginado<TEntity>> Buscar(IQueryable<TEntity> queryable, IBuscaPaginada<TEntity> filtro)
    {
        filtro.AplicarFiltro(ref queryable);
        filtro.AplicarOrdenacao(ref queryable);
        
        return await queryable.BuscarPaginadoAsync(filtro.Pagina, filtro.TamanhoPagina);
    }
    
    public virtual async Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).FirstOrDefaultAsync();
    }
    
    public async Task<int> Count(Expression<Func<TEntity, bool>> predicate) => await _dbSet.CountAsync(predicate);

    public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AnyAsync(predicate);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            // free managed resources
            Context.Dispose();
        }

        _isDisposed = true;
    }
    
    ~Repository()
    {
        Dispose(false);
    }
}