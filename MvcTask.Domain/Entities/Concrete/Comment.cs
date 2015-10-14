namespace MvcTask.Domain.Entities.Concrete
{
    using System;

    public class Comment : Entity<Guid>
    {
        public string Name { get; set; }

        public string Body { get; set; }

        public Guid? GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}