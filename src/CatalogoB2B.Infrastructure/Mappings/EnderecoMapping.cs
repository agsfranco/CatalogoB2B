using CatalogoB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoB2B.Infrastructure.Mappings
{
    public class EnderecoMapping : BaseEntityMapping<Endereco>
    {
        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.ToTable("Enderecos");

            builder.Property(e => e.Logradouro).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Numero).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Complemento).HasMaxLength(100);
            builder.Property(e => e.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Estado).IsRequired();
            builder.Property(e => e.CEP).HasMaxLength(8).IsRequired();
            builder.Property(e => e.Pais).HasMaxLength(60).IsRequired();
            builder.Property(e => e.FornecedorId).IsRequired();

            builder.HasOne(e => e.Fornecedor)
                   .WithMany(f => f.Enderecos)
                   .HasForeignKey(e => e.FornecedorId)
                   .IsRequired();
        }
    }
}