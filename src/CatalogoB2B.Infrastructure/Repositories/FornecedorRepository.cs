using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Interfaces;
using CatalogoB2B.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoB2B.Infrastructure.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CatalogoDbContext context) : base(context) { }

        public async Task<Fornecedor?> ObterComEnderecoPorDocumentoAsync(string documento)
        {
            return await _dbSet.AsNoTracking()
                               .Include(f => f.Enderecos)
                               .FirstOrDefaultAsync(f => f.Documento == documento);            
        }

        public async Task<Fornecedor?> ObterComEnderecoPorIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking()
                               .Include(f => f.Enderecos)
                               .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor?> ObterPorDocumentoAsync(string documento)
        {
            return await _dbSet.AsNoTracking()
                               .FirstOrDefaultAsync(f => f.Documento == documento);
        }
    }
}