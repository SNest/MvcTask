namespace MvcTask.Infrastructure.Concrete.UnitOfWork
{
    using System.Data.Entity.Validation;
    using System.Text;

    using Domain.Abstract.Repositories;
    using Domain.Entities.Abstract;
    using Repositories;
    using Context.Abstract;

    internal class EfUnitOfWork
    {
        private readonly IContext db;

        public EfUnitOfWork(IContext db)
        {
            this.db = db;
        }

        public IGenericRepository<TEntity, TPrimaryKey> Entities<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>
        {
            IGenericRepository<TEntity, TPrimaryKey> entityRepository =
                new EfGenericRepository<TEntity, TPrimaryKey>(this.db);
            return entityRepository;
        }

        public void Save()
        {
            try
            {
                this.db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }
    }
}