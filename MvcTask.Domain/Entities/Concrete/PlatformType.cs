namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class PlatformType
    {
        public PlatformType()
        {
            this.Games = new HashSet<Game>();
        }

        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}