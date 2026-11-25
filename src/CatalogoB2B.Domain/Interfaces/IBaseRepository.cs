using CatalogoB2B.Domain.Entities;

namespace CatalogoB2B.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ListarAsync(bool exibirInativos = false);
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(Guid id);
    }
}