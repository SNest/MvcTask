namespace MvcTask.Application.AppServices.Concrete
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Application.Utils;
    using MvcTask.Domain.Abstract.UnitOfWork;
    using MvcTask.Domain.Entities.Concrete;

    using NLog;

    public class CommentAppService : ICommentAppService
    {
        private readonly ILogger logger;

        private readonly IUnitOfWork unitOfWork;

        public CommentAppService(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public virtual IEnumerable<CommentDto> Get()
        {
            try
            {
                var query = this.unitOfWork.Entities<Comment, long>().Get();
                if (query != null)
                {
                    return Mapper.Map<List<CommentDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Items of {0} are not found", typeof(Comment).Name), "");
        }

        public virtual CommentDto Get(long id)
        {
            try
            {
                var query = this.unitOfWork.Entities<Comment, long>().Get(id);
                if (query != null)
                {
                    return Mapper.Map<CommentDto>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Item of {0} is not found", typeof(Comment).Name), "");
        }
        public IEnumerable<CommentDto> GetByGameKey(string key)
        {
            try
            {
                var query = this.unitOfWork.Entities<Game, long>().Find(game => game.Key == key);
                if (query != null)
                {
                    return Mapper.Map<List<CommentDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Item of Comment with Key - {0} is not found", key), "");
        }

        public virtual void Create(CommentDto item)
        {
            this.unitOfWork.Entities<Comment, long>().Create(Mapper.Map<Comment>(item));
        }

        public virtual void Update(CommentDto item)
        {
            this.unitOfWork.Entities<Comment, long>().Update(Mapper.Map<Comment>(item));
        }

        public virtual void Delete(long id)
        {
            this.unitOfWork.Entities<Comment, long>().Delete(id);
        }
    }
}
