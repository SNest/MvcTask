namespace MvcTask.Application.AppServices.Concrete
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO.MemoryMappedFiles;
    using System.Linq;

    using Abstract;

    using AutoMapper;

    using Domain.Abstract.UnitOfWork;
    using Domain.Entities.Concrete;

    using MvcTask.Application.DTOs;

    using NLog;

    internal class GameAppService : IAppService
    {
        private readonly Logger logger;

        private readonly IUnitOfWork unitOfWork;

        public GameAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public void CreateGame(Game game)
        {
            try
            {
                this.unitOfWork.Entities<Game, Guid>().Create(game);
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public void EditGame(Game game)
        {
            try
            {
                this.unitOfWork.Entities<Game, Guid>().Update(game);
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public void DeleteGame(Guid id)
        {
            try
            {
                this.unitOfWork.Entities<Game, Guid>().Delete(id);
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public GameDto GetByKey(string key)
        {
            var game = new GameDto();
            try
            {
                var query = this.unitOfWork.Entities<Game, Guid>().;
                if (query != null)
                {
                    games = Mapper.Map<List<GameDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public IEnumerable<GameDto> GetAll()
        {
            var games = new List<GameDto>();
            try
            {
                var query = this.unitOfWork.Entities<Game, Guid>().Get();
                if (query != null)
                {
                    games = Mapper.Map<List<GameDto>>(query);
                }
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
            return games;
        }
    }
}