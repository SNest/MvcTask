using System;
using System.Collections.Generic;

namespace MvcTask.Domain.Entities.Concrete
{
    public class Game: Entity<Guid>
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

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<PlatformType> PlatformTypes { get; set; }
    }
}
