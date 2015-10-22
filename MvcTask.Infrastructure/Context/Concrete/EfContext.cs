namespace MvcTask.Infrastructure.Context.Concrete
{
    using System.Data.Entity;

    using MvcTask.Domain.Entities.Abstract;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Infrastructure.Context.Abstract;
    using MvcTask.Infrastructure.Context.Concrete.Configuration;

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
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<PlatformType> PlatformTypes { get; set; }

        public IDbSet<TEntity> Set<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new PlatformTypeConfiguration());
            modelBuilder.Configurations.Add(new PublisherConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());
        }
    }
}