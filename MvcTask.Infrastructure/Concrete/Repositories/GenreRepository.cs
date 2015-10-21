
namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Infrastructure.Context.Abstract;

    public class GenreRepository : EfRepository<Genre, long>, IGenreRepository
    {
         private readonly IContext db;

        public GenreRepository(IContext db)
            : base(db)
        {
            this.db = db;
        }
    }
}
