namespace MvcTask.Domain.Entities.Concrete
{
    using Abstract;

    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}