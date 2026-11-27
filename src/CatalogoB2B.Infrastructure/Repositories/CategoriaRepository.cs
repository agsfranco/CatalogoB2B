using CatalogoB2B.Domain.Entities;
using CatalogoB2B.Domain.Interfaces;
using CatalogoB2B.Infrastructure.Context;

namespace CatalogoB2B.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CatalogoDbContext context) : base(context) { }
    }
}