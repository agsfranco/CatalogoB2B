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
            _dbSet.Add(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            _dbSet.Update(entidade);
            await _context.SaveChangesAsync();
        }        

        public async Task<IEnumerable<T>> ListarAsync(StatusFiltro statusFiltro = StatusFiltro.Ativos)
        {
            return await _dbSet.AsNoTracking().FiltrarPorStatus(statusFiltro).ToListAsync();
        }

        public async Task<T?> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AtivarAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                entity.Ativar();
                await _context.SaveChangesAsync();
            }            
        }
        public async Task InativarAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                entity.Inativar();
                await _context.SaveChangesAsync();
            }
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