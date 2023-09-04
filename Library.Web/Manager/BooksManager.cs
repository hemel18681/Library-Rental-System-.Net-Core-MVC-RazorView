using EF.Core.Repository.Manager;
using Library.Web.Interfaces.Manager;
using Library.Web.Models;
using Library.Web.Models.DomainModels;
using Library.Web.Repository;

namespace Library.Web.Manager
{
    public class BooksManager : CommonManager<Books>, IBooksManager
    {
        public BooksManager(LibraryDbContext _dbContext) : base(new BooksRepository(_dbContext))
        {
        }
    }
}
