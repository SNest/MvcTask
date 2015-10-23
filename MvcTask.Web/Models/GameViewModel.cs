namespace MvcTask.Web.Models
{
    using System.Collections.Generic;

    using MvcTask.Application.DTOs.Concrete;

    public class GameViewModel
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public short UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        public long? PublisherId { get; set; }

        public PublisherViewModel Publisher { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public IEnumerable<PlatformTypeDto> PlatformTypes { get; set; }
    }
}