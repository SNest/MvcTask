namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Infrastructure.Context.Abstract;

    public class PlatformTypeRepository : EfRepository<PlatformType, long>, IPlatformTypeRepository
    {
         private readonly IContext db;

        public PlatformTypeRepository(IContext db)
            : base(db)
        {
            this.db = db;
        }
    }
}
