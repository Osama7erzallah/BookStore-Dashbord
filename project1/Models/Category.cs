using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace project1.Models
{
    [Index (nameof(Name),IsUnique =true)]
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }= DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public List<BookCategory> Books { get; set; }= new List<BookCategory>();
    }
}
