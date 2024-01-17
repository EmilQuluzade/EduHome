using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string? BookName { get; set; } // Nullable string
        public string? AuthorName { get; set; } // Nullable string
    }
}
