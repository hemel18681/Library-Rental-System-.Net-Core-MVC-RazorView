using EF.Core.Repository.Repository;
using Library.Web.Interfaces.Repository;
using Library.Web.Models;
using Library.Web.Models.DomainModels;
using Library.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Repository
{
    public class RentsRepository : CommonRepository<Rents>, IRentsRepository
    {
        LibraryDbContext _dbContext;
        public RentsRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Rents> GetAllRents()
        {
            return _dbContext.Rents
                .Include(r => r.StudentInformaions)
                .Include(r => r.BookInformations)
                .ToList().OrderBy(x=>x.ReturnDate);
        }

        public void ReturnABook(int rentId, int bookId)
        {
            var rentData = _dbContext.Rents.Where(r => r.RentId == rentId).First();
            rentData.ReturnDate = DateTime.Now;
            _dbContext.Rents.Update(rentData);
            var bookData = _dbContext.Books.Where(r => r.BookId == bookId).First();
            bookData.BookCount += 1;
            _dbContext.Books.Update(bookData);
            _dbContext.SaveChanges();
        }

        public void RentBooks(SelectBooksViewModel selectBooksViewModel)
        {
            for(int i=0;i<selectBooksViewModel.BooksList.Count;i++)
            {
                if (selectBooksViewModel.BooksList[i]?.CheckBox == true)
                {
                    var rent = new Rents();
                    rent.TakenDate = DateTime.Now;
                    rent.StudentId = selectBooksViewModel.StudentInformation.StudentId;
                    rent.BookId = selectBooksViewModel.BooksList[i].BookId;
                    var book = _dbContext.Books.Where(b => b.BookId == selectBooksViewModel.BooksList[i].BookId).First();
                    book.BookCount -= 1;
                    _dbContext.Books.Update(book);
                    _dbContext.Rents.Add(rent);
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
