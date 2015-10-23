namespace MvcTask.Web.Areas.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CommentCreateViewModel
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        public String Body { get; set; }

        [HiddenInput]
        public long? Author { get; set; }
    }
}