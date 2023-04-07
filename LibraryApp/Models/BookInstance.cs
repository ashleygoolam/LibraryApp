using LibraryApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class BookInstance
    {
        [Key]
        public int Id { get; set; }
        public string? IsbnNumber { get; set; }
        public BookStatus bookStatus { get; set; }

        //Relationships
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public BookIssue? BookIssue { get; set; }
    }
}
