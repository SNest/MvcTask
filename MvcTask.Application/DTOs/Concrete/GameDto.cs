namespace MvcTask.Application.DTOs.Concrete
{
    using System.Collections.Generic;

    public class GameDto : Dto<long>
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public IEnumerable<PlatformTypeDto> PlatformTypes { get; set; }
    }
}