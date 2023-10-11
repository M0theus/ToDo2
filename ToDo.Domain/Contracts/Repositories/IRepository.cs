using System.Linq.Expressions;
using ToDo.Domain.Contracts.Paginacao;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories;

public interface IRepository<T> : IDisposable where T : Entity
{
    IUnitOfWork UnitOfWork { get; }
    Task<IResultadoPaginado<T>> Buscar(IBuscaPaginada<T> filtro);
    Task<IResultadoPaginado<T>> Buscar(IQueryable<T> queryable, IBuscaPaginada<T> filtro);
    Task<List<T>> Buscar(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);
    Task<int> Count(Expression<Func<T, bool>> predicate);
    Task<bool> Any(Expression<Func<T, bool>> predicate);

}