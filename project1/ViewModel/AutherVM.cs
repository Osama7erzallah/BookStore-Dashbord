using System.ComponentModel.DataAnnotations;

namespace project1.ViewModel
{
    public class AutherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
