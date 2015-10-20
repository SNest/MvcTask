namespace MvcTask.Application.DTOs.Concrete
{
    using System.Collections.Generic;

    public class CommentDto : Dto<long>
    {
        public string Name { get; set; }

        public string Body { get; set; }

        public IEnumerable<CommentDto> ChildComments { get; set; } 
    }
}
