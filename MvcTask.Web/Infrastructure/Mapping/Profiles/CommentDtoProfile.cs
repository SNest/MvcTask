namespace MvcTask.Web.Infrastructure.Mapping.Profiles
{
    using AutoMapper;

    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class CommentDtoProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CommentDto, CommentViewModel>();
            Mapper.CreateMap<CommentViewModel, CommentDto>();
        }
    }
}