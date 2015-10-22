namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class Publisher : Entity<long>
    {
        public Publisher()
        {
            this.Games = new List<Game>();
        }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}