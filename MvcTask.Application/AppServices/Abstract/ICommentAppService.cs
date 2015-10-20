namespace MvcTask.Application.AppServices.Abstract
{
    using System.Collections.Generic;

    using MvcTask.Application.DTOs.Concrete;

    public interface ICommentAppService
    {
        IEnumerable<CommentDto> Get();

        CommentDto Get(long id);

        IEnumerable<CommentDto> GetByGameKey(string key);

        void Create(CommentDto item);

        void Update(CommentDto item);

        void Delete(long id);
    }
}