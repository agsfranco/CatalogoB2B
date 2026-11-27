using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Enums;
using CatalogoB2B.Domain.Interfaces;
using CatalogoB2B.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoB2B.Infrastructure.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CatalogoDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterPorCategoriaIdAsync(Guid categoriaId, StatusFiltro statusFiltro = StatusFiltro.Ativos)
        {
            return await  _dbSet.AsNoTracking()
                                .Where(p => p.CategoriaId == categoriaId)
                                .FiltrarPorStatus(statusFiltro)
                                .ToListAsync();
        }

        public async Task<Produto?> ObterPorCodigoSKUAsync(string codigoSKU)
        {
            return await  _dbSet.AsNoTracking()
                                .FirstOrDefaultAsync(p => p.CodigoSKU == codigoSKU);
        }

        public async Task<IEnumerable<Produto>> ObterPorFornecedorIdAsync(Guid fornecedorId, StatusFiltro statusFiltro = StatusFiltro.Ativos)
        {
            return await  _dbSet.AsNoTracking()
                                .Where(p => p.FornecedorId == fornecedorId)
                                .FiltrarPorStatus(statusFiltro)
                                .ToListAsync();
        }
    }
}