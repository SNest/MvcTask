namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Domain.Abstract.Repositories;
    using Domain.Entities.Abstract;

    using Context.Abstract;

    using NLog;

    public class EfGenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IContext db;

        private readonly Logger logger;

        public EfGenericRepository(IContext db)
        {
            this.db = db;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            try
            {
                return this.db.Set<TEntity, TPrimaryKey>();
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            try
            {
                return this.db.Set<TEntity, TPrimaryKey>().Find(id);
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        
        public virtual void Create(TEntity item)
        {
            try
            {
                this.db.Entry(item).State = EntityState.Added;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Update(TEntity item)
        {
            try
            {
                this.db.Entry(item).State = EntityState.Modified;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }

        public virtual void Delete(TPrimaryKey id)
        {
            try
            {
                this.db.Entry(this.Get(id)).State = EntityState.Deleted;
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }
    }
}
