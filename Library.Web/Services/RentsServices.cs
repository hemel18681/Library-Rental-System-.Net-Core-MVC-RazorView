using Library.Web.Interfaces;
using Library.Web.Models;
using Library.Web.Models.DomainModels;

namespace Library.Web.Services
{
    public class RentsServices
    {
        private LibraryDbContext _context;
        public RentsServices(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddARent(Rents rent)
        {
            throw new NotImplementedException();
        }

        public List<Rents> GetAll()
        {
            return _context.Rents.ToList();
        }

        public bool ReturnARent(int rentId)
        {
            throw new NotImplementedException();
        }
    }
}
