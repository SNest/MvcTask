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

        public IEnumerable<CommentDto> Comments { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public IEnumerable<PlatformTypeDto> PlatformTypes { get; set; }
    }
}