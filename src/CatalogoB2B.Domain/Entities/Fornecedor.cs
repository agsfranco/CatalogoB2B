using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Domain.Entities
{
    public class Fornecedor : BaseEntity
    {     
        public string Nome { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public string Documento { get; set; } = null!;
        public TipoFornecedor TipoFornecedor { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}