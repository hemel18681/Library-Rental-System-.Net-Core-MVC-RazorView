using EF.Core.Repository.Repository;
using Library.Web.Interfaces.Repository;
using Library.Web.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Repository
{
    public class StudentsRepository : CommonRepository<Students>, IStudentsRepository
    {
        public StudentsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
