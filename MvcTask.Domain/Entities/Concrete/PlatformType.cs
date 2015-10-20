namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class PlatformType : Entity<long>
    {
        public PlatformType()
        {
            
            this.Games = new HashSet<Game>();
        }

        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}