namespace MvcTask.Application.DTOs.Concrete
{
    using System.Collections.Generic;

    public class GenreDto : Dto<long>
    {
        public string Name { get; set; }

        public IEnumerable<GenreDto> ChildGenres { get; set; }
    }
}