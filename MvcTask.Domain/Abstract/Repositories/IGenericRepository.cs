using System;
using System.Collections.Generic;

namespace MvcTask.Domain.Abstract.Repositories
{
    using Entities.Abstract;

    public interface IGenericRepository<TEntity, in TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPrimaryKey id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TPrimaryKey id);
    }
}