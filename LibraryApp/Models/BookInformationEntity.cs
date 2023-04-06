using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class BookInformationEntity
    {
        [Key]
        public int BookId { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Publisher { get; set; }

        public string? Type { get; set; }

        public int CurrentAmount { get; set; }

        public int TotalAmount { get; set; }

        public string? Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public string? BookLocation { get; set;}
    }
}
