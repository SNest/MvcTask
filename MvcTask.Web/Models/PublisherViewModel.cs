namespace MvcTask.Web.Models
{
    using System.Collections.Generic;

    using MvcTask.Application.DTOs.Concrete;

    public class PublisherViewModel
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string HomePage { get; set; }

        public IEnumerable<GameDto> Games { get; set; }
    }
}