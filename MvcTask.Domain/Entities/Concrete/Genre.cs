namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class Genre
    {
        public Genre()
        {
            this.ChildGenres = new HashSet<Genre>();
            this.Games = new HashSet<Game>();
        }
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }

        public Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
