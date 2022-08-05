using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Page
    {
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Mininmum length is 2")]
        //[Display(Name = "Fruits")]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(5, ErrorMessage = "Mininmum length is 5")]
        public string Content { get; set; }

        public int Sorting { get; set; }
    }
}
