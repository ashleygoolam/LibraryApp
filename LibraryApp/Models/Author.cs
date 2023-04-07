using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Biography { get; set; }

        //Relationships
        public List<Author_Book>? Author_Book { get; set;}
    }
}
