namespace MvcTask.Application.AppServices.Abstract
{
    using System.Collections.Generic;

    using MvcTask.Application.DTOs.Concrete;

    public interface IPublisherAppService
    {
        IEnumerable<PublisherDto> Get();

        PublisherDto Get(long id);

        PublisherDto GetByCompanyName(string company);

        void Create(PublisherDto item);

        void Update(PublisherDto item);

        void Delete(long id);
    }
}
