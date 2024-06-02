using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class Auther
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now; 
    }
}
