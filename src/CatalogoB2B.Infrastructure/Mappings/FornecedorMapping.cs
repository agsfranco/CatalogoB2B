using CatalogoB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoB2B.Infrastructure.Mappings
{
    public class FornecedorMapping : BaseEntityMapping<Fornecedor>
    {
        public override void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Fornecedores");

            builder.HasIndex(f => f.Documento).IsUnique();

            builder.Property(f => f.Nome).HasMaxLength(100).IsRequired();
            builder.Property(f => f.NomeFantasia).HasMaxLength(100);
            builder.Property(f => f.Documento).HasMaxLength(14).IsRequired();
            builder.Property(f => f.TipoFornecedor).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(100);
            builder.Property(f => f.Telefone).HasMaxLength(100);
        }
    }
}