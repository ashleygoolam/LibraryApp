using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Dues
    {
        [Key]
        public int DueId { get; set; }
        public int BorrowersId { get; set; }
        public string? Reason { get; set; }
        public int IssuedById { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public bool IsPaidFor { get; set; }
    }
}
