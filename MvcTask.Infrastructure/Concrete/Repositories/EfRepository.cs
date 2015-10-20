namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Abstract;
    using MvcTask.Infrastructure.Context.Abstract;

    public class EfRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IContext db;

        public EfRepository(IContext db)
        {
            this.db = db;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return this.db.Set<TEntity, TPrimaryKey>();
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return this.db.Set<TEntity, TPrimaryKey>().Find(id);
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
        {
            return this.db.Set<TEntity, TPrimaryKey>().Where(predicate).ToList();
        }

        public virtual void Create(TEntity item)
        {
            this.db.Entry(item).State = EntityState.Added;
        }

        public virtual void Update(TEntity item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(TPrimaryKey id)
        {
            this.db.Entry(this.Get(id)).State = EntityState.Deleted;
        }
    }
}