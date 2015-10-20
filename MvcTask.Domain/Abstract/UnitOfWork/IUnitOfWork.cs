namespace MvcTask.Domain.Abstract.UnitOfWork
{
    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Abstract;

    public interface IUnitOfWork
    {
        IGameRepository Games { get; }

        ICommentRepository Comments { get; }

        IGenreRepository Genres { get; }

        IPlatformTypeRepository PlatformTypes { get; }

        IRepository<TEntity, TPrimaryKey> Entities<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;

        void Save();
    }
}