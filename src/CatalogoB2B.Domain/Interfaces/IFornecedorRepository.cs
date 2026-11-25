using CatalogoB2B.Domain.Entities;

namespace CatalogoB2B.Domain.Interfaces
{
    public interface IFornecedorRepository: IBaseRepository<Fornecedor>
    {
        Task<Fornecedor?> ObterComEnderecoPorIdAsync(Guid id);
        Task<Fornecedor?> ObterComEnderecoPorDocumentoAsync(string documento);
        Task<Fornecedor?> ObterPorDocumentoAsync(string documento);
    }
}