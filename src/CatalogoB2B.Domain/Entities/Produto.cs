using CatalogoB2B.Domain.Enums;
using CatalogoB2B.Domain.Exceptions;

namespace CatalogoB2B.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string CodigoSKU { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string? DescricaoTecnica { get; set; }
        public decimal Preco { get; private set; }
        public UnidadeMedida UnidadeMedida { get; set; } = UnidadeMedida.UN;
        public decimal Estoque { get; set; }
        public Guid FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; } = null!;
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;

        protected Produto() { }

        public Produto(string codigoSKU, string nome, string? descricaoTecnica, decimal preco, UnidadeMedida unidadeMedida, decimal estoque, Guid fornecedorId, Guid categoriaId)
        {
            CodigoSKU = codigoSKU;
            Nome = nome;
            DescricaoTecnica = descricaoTecnica;
            UnidadeMedida = unidadeMedida;
            Estoque = estoque;
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;

            this.AlterarPreco(preco);
        }

        public void AlterarPreco (decimal preco)
        {
            if (preco >= 0)
            {
                Preco = preco;
            } else
            {
                throw new DomainException("O preço não pode ser menor do que zero!");
            }
        }

        public decimal EstoqueDisponivel()
        {
            return Estoque >= 0 ? Estoque : 0;
        }
    }
}