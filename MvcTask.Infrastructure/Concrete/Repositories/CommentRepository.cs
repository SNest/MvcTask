namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Domain.Abstract.Repositories;
    using Domain.Entities.Concrete;
    using Context.Abstract;

    using NLog;

    internal class CommentRepository : EfGenericRepository<Comment, Guid>, ICommentRepository
    {
        private readonly IContext db;

        private readonly Logger logger;

        public CommentRepository(IContext db)
            : base(db)
        {
            this.db = db;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            try
            {
                return this.db.Set<Comment, Guid>().Where(predicate).ToList();
            }
            catch (Exception exception)
            {
                this.logger.Trace(exception.StackTrace);
                throw;
            }
        }
    }
}