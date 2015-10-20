namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Infrastructure.Context.Abstract;

    public class CommentRepository : EfRepository<Comment, long>, ICommentRepository
    {
        private readonly IContext db;

        public CommentRepository(IContext db)
            : base(db)
        {
            this.db = db;
        }
    }
}