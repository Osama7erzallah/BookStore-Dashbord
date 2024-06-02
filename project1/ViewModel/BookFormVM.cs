using Microsoft.AspNetCore.Mvc.Rendering;
using project1.Models;
using System.ComponentModel.DataAnnotations;

namespace project1.ViewModel
{
    public class BookFormVM
    {
        public int Id {  get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        [Display(Name ="Auther")]
        public int AutherId { get; set; }
         public List<SelectListItem>? Authers { get; set; }

        public string Publisher { get; set; } = null!;
        [Display(Name = "Pulish Date")]

        public DateTime PublisherDate { get; set; }= DateTime.Now;
        [Display(Name ="Book Image")]
        public IFormFile? imageURL { get; set; }

        public List<SelectListItem>? Categories { get; set; }

        public List<int> SelectedCategories { get; set; } = new List<int>();

    }
}
