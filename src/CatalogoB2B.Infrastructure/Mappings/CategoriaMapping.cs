using CatalogoB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoB2B.Infrastructure.Mappings
{
    public class CategoriaMapping : BaseEntityMapping<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Categorias");

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        }
    }
}