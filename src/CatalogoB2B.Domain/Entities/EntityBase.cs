namespace CatalogoB2B.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.CreateVersion7();
        public bool Ativo { get; private set; } = true;

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