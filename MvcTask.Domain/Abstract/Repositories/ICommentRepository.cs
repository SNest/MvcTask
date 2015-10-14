namespace MvcTask.Domain.Abstract.Repositories
{
    using System;
    using System.Collections.Generic;

    using Entities.Concrete;

    public interface ICommentRepository: IGenericRepository<Comment, Guid>
    {
        IEnumerable<Comment> Find(Func<Comment, bool> predicate);
    }
}