using CatalogoB2B.Domain.Entities;

namespace CatalogoB2B.Domain.Interfaces
{
    public interface IProdutoRepository: IBaseRepository<Produto>
    {
        Task<Produto?> ObterPorCodigoSKUAsync(string codigoSKU);
        Task<IEnumerable<Produto>> ObterPorFornecedorIdAsync(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterPorCategoriaIdAsync(Guid categoriaId);
    }
}