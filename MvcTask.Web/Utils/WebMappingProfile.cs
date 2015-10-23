namespace MvcTask.Web.Utils
{
    using AutoMapper;

    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Areas.Common.Models;
    using MvcTask.Web.Models;

    public class WebMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CommentDto, CommentViewModel>().ReverseMap();
            Mapper.CreateMap<GameDto, GameViewModel>().ReverseMap();
            Mapper.CreateMap<GameDto, GameCreateViewModel>().ReverseMap();
            Mapper.CreateMap<PublisherDto, PublisherViewModel>().ReverseMap(); 
        }
    }
}