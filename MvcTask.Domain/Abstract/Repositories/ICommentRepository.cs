namespace MvcTask.Domain.Abstract.Repositories
{
    using MvcTask.Domain.Entities.Concrete;

    public interface ICommentRepository : IRepository<Comment, long>
    {
    }
}