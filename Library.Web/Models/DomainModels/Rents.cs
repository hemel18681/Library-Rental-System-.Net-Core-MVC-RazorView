using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Web.Models.DomainModels
{
    public class Rents
    {
        [Key]
        public int RentId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [ForeignKey("StudentId")]
        public Students StudentInformaions { get; set; }
        [ForeignKey("BookId")]
        public Books BookInformations { get; set; }
    }
}
