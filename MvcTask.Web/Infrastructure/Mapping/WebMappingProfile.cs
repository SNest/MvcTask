namespace MvcTask.Web.Infrastructure.Mapping
{
    using AutoMapper;

    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class WebMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CommentDto, CommentViewModel>().ReverseMap();
            Mapper.CreateMap<GameDto, GameViewModel>().ReverseMap(); 
        }
    }
}