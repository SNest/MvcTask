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

    public class GameAppService : IGameAppService
    {
        private readonly ILogger logger;

        private readonly IUnitOfWork unitOfWork;

        public GameAppService(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public virtual IEnumerable<GameDto> Get()
        {
            try
            {
                var query = this.unitOfWork.Games.Get();
                if (query == null)
                {
                    throw new ValidationException(String.Format("Items of {0} are not found", typeof(Game).Name), "");
                }
                return Mapper.Map<List<GameDto>>(query);
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual GameDto Get(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ValidationException("Id must be greater than 0", "id");
                }
                var query = this.unitOfWork.Games.Get(id);
                if (query == null)
                {
                    throw new ValidationException(String.Format("Item of {0} is not found", typeof(Game).Name), "");
                }
                return Mapper.Map<GameDto>(query);
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public GameDto GetByKey(string key)
        {
            try
            {
                var query = this.unitOfWork.Games.Find(game => game.Key == key).SingleOrDefault();
                if (query == null)
                {
                    throw new ValidationException(String.Format("Item of {0} is not found", typeof(Game).Name), "");
                }
                return Mapper.Map<GameDto>(query);
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public IEnumerable<GameDto> GetByGenre(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ValidationException("Invalid id", "id");
                }
                var query = this.unitOfWork.Genres.Get(id);
                if (query == null)
                {
                    throw new ValidationException(String.Format("Item of {0} is not found", typeof(Game).Name), "");
                }
                return Mapper.Map<IEnumerable<GameDto>>(
                    this.unitOfWork.Games.Get().Where(x => x.Genres.Contains(query)));
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public IEnumerable<GameDto> GetByPlatformTypes(List<int> platformIdList)
        {
            if (platformIdList == null)
            {
                throw new ValidationException("paltformList is empty", "paltformList");
            }
            if (
                platformIdList.Select(Id => this.unitOfWork.PlatformTypes.Get(Id))
                    .Any(platformType => platformType == null))
            {
                throw new ValidationException("Unexisting PlatforType id", "Id");
            }
            var games = new List<Game>();
            foreach (var platformType in
                platformIdList.Select(id => this.unitOfWork.PlatformTypes.Find(x => x.Id == id).FirstOrDefault())
                    .Where(platformType => platformType != null))
            {
                games.AddRange(platformType.Games);
            }

            return Mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
        }

        public virtual void Create(GameDto item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Invalid id", "id");
                }
                if (!this.IsUniqueKey(item.Key))
                {
                    throw new ValidationException("Key is not unique", "Key");
                }
                this.unitOfWork.Games.Create(Mapper.Map<Game>(item));
                this.unitOfWork.Save();
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Update(GameDto item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Item can not be null", "Key");
                }
                this.unitOfWork.Games.Update(Mapper.Map<Game>(item));
                this.unitOfWork.Save();
            }
            catch (ValidationException exception)
            {
                this.logger.Debug(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
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
                    throw new ValidationException("Invalid id", "");
                }
                this.unitOfWork.Games.Delete(id);
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        private bool IsUniqueKey(string key)
        {
            var game = this.unitOfWork.Games.Get().FirstOrDefault(x => x.Key == key);
            return game == null;
        }
    }
}