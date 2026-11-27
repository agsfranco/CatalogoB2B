using CatalogoB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoB2B.Infrastructure.Context
{
    public class CatalogoDbContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options) { }
    }
}