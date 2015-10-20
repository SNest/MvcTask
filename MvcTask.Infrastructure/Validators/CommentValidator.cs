namespace MvcTask.Infrastructure.Validators
{
    using System.Linq;

    using FluentValidation;

    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Concrete;

    class CommentValidator : AbstractValidator<Comment>
    {
        private readonly ICommentRepository CommentRepository;

        CommentValidator(ICommentRepository CommentRepository)
        {
            this.CommentRepository = CommentRepository;
            this.RuleFor(comment => comment.Name).Must(this.HasUniqueName);
        }

        private bool HasUniqueName(string name)
        {
            return this.CommentRepository.Get().SingleOrDefault(comment => comment.Name == name) == null;
        }
    }
}
