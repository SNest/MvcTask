namespace MvcTask.Domain.Abstract.UnitOfWork
{
    using Repositories;
    using Entities.Abstract;

    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TPrimaryKey> Entities<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>;

        void Save();
    }
}