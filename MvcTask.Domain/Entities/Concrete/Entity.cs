namespace MvcTask.Domain.Entities.Concrete
{
    using MvcTask.Domain.Entities.Abstract;

    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}