namespace MvcTask.Web.Infrastructure.Mapping.Profiles
{
    using AutoMapper;

    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class PublisherDtoProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PublisherDto, PublisherViewModel>();
            Mapper.CreateMap<PublisherViewModel, PublisherDto>();
        }
    }
}