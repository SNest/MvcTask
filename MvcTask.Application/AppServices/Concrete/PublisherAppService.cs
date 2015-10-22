namespace MvcTask.Application.AppServices.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Application.Utils;
    using MvcTask.Domain.Abstract.UnitOfWork;
    using MvcTask.Domain.Entities.Concrete;

    using NLog;

    public class PublisherAppService : IPublisherAppService
    {
        private readonly ILogger logger;

        private readonly IUnitOfWork unitOfWork;

        public PublisherAppService(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public virtual IEnumerable<PublisherDto> Get()
        {
            try
            {
                var query = this.unitOfWork.Entities<Publisher, long>().Get();
                if (query != null)
                {
                    return Mapper.Map<List<PublisherDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Items of {0} are not found", typeof(Publisher).Name), "");
        }

        public virtual PublisherDto Get(long id)
        {
            try
            {
                var query = this.unitOfWork.Entities<Publisher, long>().Get(id);
                if (query != null)
                {
                    return Mapper.Map<PublisherDto>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Item of {0} is not found", typeof(Publisher).Name), "");
        }

        public PublisherDto GetByCompanyName(string company)
        {
            try
            {
                if (string.IsNullOrEmpty(company))
                {
                    throw new ValidationException("Field company is not valid", "company");
                }
                var query =
                    this.unitOfWork.Entities<Publisher, long>()
                        .Find(game => game.CompanyName == company)
                        .SingleOrDefault();
                if (query == null)
                {
                    throw new ValidationException(String.Format("Item of {0} is not found", typeof(Publisher).Name), "");
                }
                return Mapper.Map<PublisherDto>(query);
            }
            catch (ValidationException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Create(PublisherDto item)
        {
            try
            {
                if (!this.IsUniqueCompanyName(item.CompanyName))
                {
                    throw new ValidationException("Company name is not unique", "Key");
                }
                this.unitOfWork.Entities<Publisher, long>().Create(Mapper.Map<Publisher>(item));
                this.unitOfWork.Save();
            }
            catch (ValidationException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Update(PublisherDto item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Item equals null", "Key");
                }
                this.unitOfWork.Entities<Publisher, long>().Update(Mapper.Map<Publisher>(item));
                this.unitOfWork.Save();
            }
            catch (ValidationException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Delete(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ValidationException("Id is not valid", "Key");
                }
                this.unitOfWork.Entities<Publisher, long>().Delete(id);
                this.unitOfWork.Save();
            }
            catch (ValidationException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        private bool IsUniqueCompanyName(string company)
        {
            try
            {
                if (string.IsNullOrEmpty(company))
                {
                    throw new ValidationException("Field company is not valid", "company");
                }
                var game =
                    this.unitOfWork.Entities<Publisher, long>().Get().FirstOrDefault(x => x.CompanyName == company);
                return game == null;
            }
            catch (ValidationException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }
    }
}