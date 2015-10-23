namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class Game : Entity<long>
    {
        public Game()
        {
            this.Comments = new HashSet<Comment>();
            this.Genres = new HashSet<Genre>();
            this.PlatformTypes = new HashSet<PlatformType>();
        }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public short UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        public long? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<PlatformType> PlatformTypes { get; set; }
    }
}