namespace CatalogoB2B.Domain.Entities
{
    public class Fornecedor : EntityBase
    {     
        public string RazaoSocial { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public string Documento { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public Guid? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}