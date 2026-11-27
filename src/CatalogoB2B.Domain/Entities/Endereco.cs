using CatalogoB2B.Domain.Enums;

namespace CatalogoB2B.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public TipoEndereco TipoEndereco { get; set; }
        public string Logradouro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public EstadoBrasil Estado { get; set; }
        public string CEP
        {
            get => field;
            set => field = string.IsNullOrWhiteSpace(value) ? string.Empty : new string(value.Where(char.IsDigit).ToArray());
        } = null!;
        public string Pais { get; set; } = null!;
        public Guid FornecedorId { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
    }
}