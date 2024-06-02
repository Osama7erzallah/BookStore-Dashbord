using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    [Index (nameof(Title),IsUnique =true)]
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = null!;
        public string Description { get; set; }

        public int AutherId { get; set; }
        public Auther Auther { get; set; }

        public string Publisher { get; set; } = null! ;
        public DateTime PublisherDate { get; set; }
        public string? imageURL { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public List<BookCategory> Categories { get; set; }= new List<BookCategory>();





    }
}
