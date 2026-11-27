using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Domain.Entities
{
    public class Fornecedor : BaseEntity
    {     
        public string Nome { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Produto>? Produtos { get; set; }
        public string Documento 
        { 
            get => field;
            set => field = string.IsNullOrWhiteSpace(value) ? string.Empty : new string(value.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
        } = null!;
        public string? Email
        {
            get => field;
            set => field = value?.Trim().ToLowerInvariant();
        }
        public string? Telefone 
        { 
            get => field;
            set => field = string.IsNullOrWhiteSpace(value) ? null : new string(value.Where(char.IsDigit).ToArray());
        }        
    }
}