using EF.Core.Repository.Repository;
using Library.Web.Interfaces.Repository;
using Library.Web.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Repository
{
    public class BooksRepository : CommonRepository<Books>, IBooksRepository
    {
        public BooksRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
