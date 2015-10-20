namespace MvcTask.Web.Models
{
    using System.Collections.Generic;

    public class CommentViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public IEnumerable<CommentViewModel> ChildComments { get; set; } 
    }
}