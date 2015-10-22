namespace MvcTask.Application.AppServices.Abstract
{
    using System.Collections.Generic;

    using MvcTask.Application.DTOs.Concrete;

    public interface IGameAppService
    {
        IEnumerable<GameDto> Get();

        GameDto Get(long id);

        GameDto GetByKey(string key);

        IEnumerable<GameDto> GetByGenre(string name);

        IEnumerable<GameDto> GetByPlatformTypes(List<int> platformIdList);

        void Create(GameDto item);

        void Update(GameDto item);

        void Delete(long id);
    }
}