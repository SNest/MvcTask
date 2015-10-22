namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class Genre : Entity<long>
    {
        public Genre()
        {
            this.ChildGenres = new HashSet<Genre>();
            this.Games = new HashSet<Game>();
        }

        public string Name { get; set; }

        public long? ParentGenreId { get; set; }

        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}