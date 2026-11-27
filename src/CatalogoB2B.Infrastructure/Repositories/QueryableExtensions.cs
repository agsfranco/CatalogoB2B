using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Infrastructure.Repositories
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> FiltrarPorStatus<T>(this IQueryable<T> query, StatusFiltro statusFiltro) where T : BaseEntity
        {
            return statusFiltro switch
            {
                StatusFiltro.Ativos => query.Where(q => q.Ativo),
                StatusFiltro.Inativos => query.Where(q => !q.Ativo),
                StatusFiltro.Todos or _ => query
            };
        }
    }
}