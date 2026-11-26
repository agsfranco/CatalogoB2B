using CatalogoB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoB2B.Infrastructure.Mappings
{
    public class ProdutoMapping : BaseEntityMapping<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.HasIndex(p => p.CodigoSKU).IsUnique();

            builder.ToTable("Produtos");

            builder.Property(p => p.CodigoSKU).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.DescricaoTecnica).HasMaxLength(255);
            builder.Property(p => p.Preco).HasPrecision(18,2);
            builder.Property(p => p.UnidadeMedida).IsRequired();
            builder.Property(p => p.Estoque).HasPrecision(18,4);

            builder.HasOne(p => p.Fornecedor)
                   .WithMany(f => f.Produtos)
                   .HasForeignKey(p => p.FornecedorId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
            
            builder.HasOne(p => p.Categoria)
                   .WithMany(c => c.Produtos)
                   .HasForeignKey(p => p.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}