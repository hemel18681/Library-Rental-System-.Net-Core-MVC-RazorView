using EF.Core.Repository.Manager;
using Library.Web.Interfaces.Manager;
using Library.Web.Models;
using Library.Web.Models.DomainModels;
using Library.Web.Repository;

namespace Library.Web.Manager
{
    public class StudentsManager : CommonManager<Students>, IStudentsManager
    {
        public StudentsManager(LibraryDbContext _dbContext) : base(new StudentsRepository(_dbContext))
        {

        }
    }
}
