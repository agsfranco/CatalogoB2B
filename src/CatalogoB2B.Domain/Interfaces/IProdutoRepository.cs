using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Domain.Interfaces
{
    public interface IProdutoRepository: IBaseRepository<Produto>
    {
        Task<Produto?> ObterPorCodigoSKUAsync(string codigoSKU);
        Task<IEnumerable<Produto>> ObterPorFornecedorIdAsync(Guid fornecedorId, StatusFiltro statusFiltro = StatusFiltro.Ativos);
        Task<IEnumerable<Produto>> ObterPorCategoriaIdAsync(Guid categoriaId, StatusFiltro statusFiltro = StatusFiltro.Ativos);
    }
}