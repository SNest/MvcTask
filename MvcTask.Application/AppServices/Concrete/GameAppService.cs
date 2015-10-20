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
                var query = this.unitOfWork.Entities<Game, long>().Get();
                if (query != null)
                {
                    return Mapper.Map<List<GameDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Items of {0} are not found", typeof(Game).Name), "");
        }

        public virtual GameDto Get(long id)
        {
            try
            {
                var query = this.unitOfWork.Entities<Game, long>().Get(id);
                if (query != null)
                {
                    return Mapper.Map<GameDto>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            throw new ValidationException(String.Format("Item of {0} is not found", typeof(Game).Name), "");
        }

        public GameDto GetByKey(string key)
        {
            var instance = new GameDto();
            try
            {
                var query = this.unitOfWork.Entities<Game, long>().Find(game => game.Key == key).SingleOrDefault();
                if (query != null)
                {
                    instance = Mapper.Map<GameDto>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            return instance;
        }

        public IEnumerable<GameDto> GetByGenre(string name)
        {
            var instance = new List<GameDto>();
            try
            {
                ////var genres = this.unitOfWork.Entities<Genre, long>().Find(genre => genre.Name == name).ToList();
                ////var subGenres = this.unitOfWork.Entities<Genre, long>().Find(genre => genre.Name == name).Select(genre => genre.ChildGenres).Cast<>();

                ////var query = genres.Join(subGenres);

                //if (query != null)
                //{
                //    instance = Mapper.Map<List<GameDto>>(query);
                //}
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            return instance;
        }

        public IEnumerable<GameDto> GetByPlatformTypes(List<int> platformIdList)
        {
            if (platformIdList == null) throw new ValidationException("paltformList is empty", "paltformList");
            if (platformIdList.Select(Id => this.unitOfWork.PlatformTypes.Get(Id)).Any(platformType => platformType == null))
            {
                throw new ValidationException("Unexisting PlatforType id", "Id");
            }
            var games = new List<Game>();
            foreach (var platformType in platformIdList.Select(id => this.unitOfWork.PlatformTypes.Find(x => x.Id == id).FirstOrDefault()).Where(platformType => platformType != null))
            {
                games.AddRange(platformType.Games);
            }

            return Mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
        }

        public virtual void Create(GameDto item)
        {
            if (!this.IsUniqueKey(item.Key))
            {
                throw new ValidationException("Key is not unique", "Key");
            }
            this.unitOfWork.Entities<Game, long>().Create(Mapper.Map<Game>(item));
            this.unitOfWork.Save();
        }

        public virtual void Update(GameDto item)
        {
            this.unitOfWork.Entities<Game, long>().Update(Mapper.Map<Game>(item));
            this.unitOfWork.Save();
        }

        public virtual void Delete(long id)
        {
            this.unitOfWork.Entities<Game, long>().Delete(id);
        }

        private bool IsUniqueKey(string key)
        {
            var game = this.unitOfWork.Entities<Game, long>().Get().FirstOrDefault(x => x.Key == key);
            return game == null;
        }
    }
}