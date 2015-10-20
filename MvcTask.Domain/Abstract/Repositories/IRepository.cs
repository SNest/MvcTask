namespace MvcTask.Domain.Abstract.Repositories
{
    using System;
    using System.Collections.Generic;

    using MvcTask.Domain.Entities.Abstract;

    public interface IRepository<TEntity, in TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPrimaryKey id);
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TPrimaryKey id);
    }
}