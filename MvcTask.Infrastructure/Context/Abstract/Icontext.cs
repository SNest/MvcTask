namespace MvcTask.Infrastructure.Context.Abstract
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Domain.Entities.Abstract;

    public interface IContext
    {
        IDbSet<TEntity> Set<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;

        DbEntityEntry Entry(object entity);

        int SaveChanges();

        void Dispose();
    }
}