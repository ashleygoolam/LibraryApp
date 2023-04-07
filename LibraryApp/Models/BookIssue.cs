using LibraryApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class BookIssue
    {
        [Key]
        public int IssueId { get; set; }
        public int BorrowersId { get; set; }
        public int BorrowingLibrariansId { get; set; }
        public int ReturningLibrariansId { get; set; }
        public DateTime TimeBorrowed { get; set; }
        public DateTime TimeReturned { get; set; }
        public BookStatus bookStatus { get; set; }

        //Relationships
        public int BookInstanceId { get; set; }
        [ForeignKey("BookInstanceId")]
        public BookInstance? BookInstance { get; set; }
    }
}
