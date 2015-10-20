namespace MvcTask.Application.DTOs.Concrete
{
    using System.Collections.Generic;

    using MvcTask.Domain.Entities.Concrete;

    public class PlatformTypeDto : Dto<long>
    {
        public string Type { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
