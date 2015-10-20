namespace MvcTask.Domain.Entities.Concrete
{
    using System.Collections.Generic;

    public class Comment : Entity<long>
    {
        public Comment()
        {
            this.ChildComments = new HashSet<Comment>();
        }

        public string Name { get; set; }

        public string Body { get; set; }

        public long? GameId { get; set; }

        public virtual Game Game { get; set; }

        public long? ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<Comment> ChildComments { get; set; }
    }
}