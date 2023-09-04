using Library.Web.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Library.Web.Models.ViewModels;

namespace Library.Web.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options): base(options) { }

        public DbSet<Books> Books { get; set; }
        public DbSet<Rents> Rents { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Library.Web.Models.ViewModels.SelectBooksViewModel>? SelectBooksViewModel { get; set; }
    }
}
