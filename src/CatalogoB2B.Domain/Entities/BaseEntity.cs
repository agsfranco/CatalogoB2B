namespace CatalogoB2B.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool Ativo { get; private set; }
        protected BaseEntity()
        {
            Id = Guid.CreateVersion7();
            Ativar();
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}