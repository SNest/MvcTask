namespace MvcTask.Infrastructure.Context.Concrete
{
    using System.Data.Entity;

    using Domain.Entities.Abstract;
    using Domain.Entities.Concrete;

    using Abstract;

    public class EfContext : DbContext, IContext
    {
        public EfContext()
            : base("DbConnection")
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public EfContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new ContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comments");
        }

        public IDbSet<TEntity> Set<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            return base.Set<TEntity>();
        }
    }
}
