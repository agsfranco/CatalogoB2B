using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Enums;
using CatalogoB2B.Domain.Interfaces;
using CatalogoB2B.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoB2B.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CatalogoDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(CatalogoDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _dbSet.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            _dbSet.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListarAsync(StatusFiltro statusFiltro = StatusFiltro.Ativos)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            query = statusFiltro switch
            {
                StatusFiltro.Ativos => query.Where(q => q.Ativo),
                StatusFiltro.Inativos => query.Where(q => !q.Ativo),
                StatusFiltro.Todos or _ => query
            };
            return await query.ToListAsync();
        }

        public async Task<T?> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}