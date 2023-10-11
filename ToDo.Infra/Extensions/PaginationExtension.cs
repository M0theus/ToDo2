using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Paginacao;

namespace ToDo.Infra.Extensions;

public static class PaginationExtension
{
    public static ResultadoPaginado<T> BuscarPaginado<T>(this IQueryable<T> query, int pagina, int tamanhoPagina) where T : class
    {
        var resultado = new ResultadoPaginado<T>(pagina, tamanhoPagina, query.Count());

        var quantidadePaginas = (double)resultado.Paginacao.Total / tamanhoPagina;
        resultado.Paginacao.TotalDePaginas = (int)Math.Ceiling(quantidadePaginas);

        var pular = (pagina - 1) * tamanhoPagina;
        resultado.Itens = query.Skip(pular).Take(tamanhoPagina).ToList();
        resultado.Paginacao.TotalNaPagina = resultado.Itens.Count;

        return resultado;
    }
    
    public static async Task<ResultadoPaginado<T>> BuscarPaginadoAsync<T>(this IQueryable<T> query, int pagina, int porPagina) where T : class
    {
        var resultado = new ResultadoPaginado<T>(pagina, porPagina, await query.CountAsync());

        var quantidadePaginas = (double)resultado.Paginacao.Total / porPagina;
        resultado.Paginacao.TotalDePaginas = (int)Math.Ceiling(quantidadePaginas);

        var pular = (pagina - 1) * porPagina;
        resultado.Itens = await query.Skip(pular).Take(porPagina).ToListAsync();
        resultado.Paginacao.TotalNaPagina = resultado.Itens.Count;
        return resultado;
    }
}