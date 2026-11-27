using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ListarAsync(StatusFiltro statusFiltro = StatusFiltro.Ativos);
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(Guid id);
    }
}