using project1.Models;

namespace project1.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; }

        public String Auther { get; set; }

        public string Publisher { get; set; } = null!;
        public DateTime PublisherDate { get; set; }
        public string imageURL { get; set; }
      public List<String> Categories { get; set; } 
    }
}
