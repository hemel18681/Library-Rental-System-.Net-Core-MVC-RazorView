using Library.Web.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.ViewModels
{
    public class BooksList
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
        public bool? CheckBox { get; set; }
    }
    public class SelectBooksViewModel
    {
        [Key]
        public int Id { get; set; }
        public Students StudentInformation { get; set; }
        public List<BooksList> BooksList { get; set; }
    }
}
