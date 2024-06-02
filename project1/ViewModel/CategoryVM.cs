using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project1.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name can not be Empty")]
        [MaxLength(30, ErrorMessage = "Max length is 30")]
        [Remote("checkName", null,ErrorMessage ="Name already Exists")]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; } 
        public DateTime UpdateTime { get; set; }
    }
}
