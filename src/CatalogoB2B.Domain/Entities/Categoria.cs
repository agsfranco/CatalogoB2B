namespace CatalogoB2B.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; } = null!;
        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}