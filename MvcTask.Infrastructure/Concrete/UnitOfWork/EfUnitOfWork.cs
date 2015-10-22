namespace MvcTask.Infrastructure.Concrete.UnitOfWork
{
    using System.Data.Entity.Validation;
    using System.Text;

    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Abstract.UnitOfWork;
    using MvcTask.Domain.Entities.Abstract;
    using MvcTask.Infrastructure.Concrete.Repositories;
    using MvcTask.Infrastructure.Context.Abstract;

    public class EfUnitOfWork : IUnitOfWork
    {
        private ICommentRepository commentRepository;

        private IGameRepository gameRepository;
        private IGenreRepository genreRepository;
        private IPlatformTypeRepository platformTypeRepository;

        private readonly IContext db;

        public EfUnitOfWork(IContext db)
        {
            this.db = db;
        }

        public IGameRepository Games
        {
            get
            {
                return this.gameRepository ?? (this.gameRepository = new GameRepository(this.db));
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                return this.commentRepository ?? (this.commentRepository = new CommentRepository(this.db));
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                return this.genreRepository ?? (this.genreRepository = new GenreRepository(this.db));
            }
        }

        public IPlatformTypeRepository PlatformTypes
        {
            get
            {
                return this.platformTypeRepository ?? (this.platformTypeRepository = new PlatformTypeRepository(this.db));
            }
        }


        public IRepository<TEntity, TPrimaryKey> Entities<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>
        {
            IRepository<TEntity, TPrimaryKey> entityRepository = new EfRepository<TEntity, TPrimaryKey>(this.db);
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