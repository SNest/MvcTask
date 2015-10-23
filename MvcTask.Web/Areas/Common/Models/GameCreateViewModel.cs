namespace MvcTask.Web.Areas.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class GameCreateViewModel
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The Price field should be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock count field should be greater than 0")]
        public short UnitsInStock { get; set; }

        [Required]
        public long PublisherId { get; set; }

        public IEnumerable<SelectListItem> Publishers { get; set; }

        public SelectList Genres { get; set; }

        public SelectList PlatforTypesList { get; set; }
    }
}