using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.DomainModels
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
