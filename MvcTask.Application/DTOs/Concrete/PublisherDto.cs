namespace MvcTask.Application.DTOs.Concrete
{
    using System.Collections.Generic;

    public class PublisherDto : Dto<long>
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public IEnumerable<GameDto> Games { get; set; }
    }
}
