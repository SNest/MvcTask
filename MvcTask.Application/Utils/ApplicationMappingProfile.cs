namespace MvcTask.Application.Utils
{
    using AutoMapper;

    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Domain.Entities.Concrete;

    public class ApplicationMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Comment, CommentDto>().ReverseMap();

            Mapper.CreateMap<Game, GameDto>().ReverseMap();

            Mapper.CreateMap<Genre, GenreDto>().ReverseMap();

            Mapper.CreateMap<PlatformType, PlatformTypeDto>().ReverseMap();
        }
    }
}
