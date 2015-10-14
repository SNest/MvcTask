namespace MvcTask.Infrastructure.Validators
{
    using System.Linq;

    using FluentValidation;

    using Domain.Entities.Concrete;

    using Domain.Abstract.Repositories;

    class CommentValidator : AbstractValidator<Comment>
    {
        private readonly ICommentRepository commentRepository;

        CommentValidator(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
            this.RuleFor(comment => comment.Name).Must(this.HasUniqueName);
        }

        private bool HasUniqueName(string name)
        {
            return this.commentRepository.Get().SingleOrDefault(comment => comment.Name == name) == null;
        }
    }
}
