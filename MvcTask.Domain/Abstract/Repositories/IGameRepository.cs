namespace MvcTask.Domain.Abstract.Repositories
{
    using MvcTask.Domain.Entities.Concrete;

    public interface IGameRepository : IRepository<Game, long>
    {
    }
}
