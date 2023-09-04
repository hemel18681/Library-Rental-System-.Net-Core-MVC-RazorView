using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using Library.Web.Interfaces.Manager;
using Library.Web.Models;
using Library.Web.Models.DomainModels;
using Library.Web.Models.ViewModels;
using Library.Web.Repository;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Manager
{
    public class RentsManager : CommonManager<Rents>, IRentsManager
    {
        RentsRepository _rentsRepository;
        public RentsManager(LibraryDbContext dbContext) : base(new RentsRepository(dbContext))
        {
            _rentsRepository = new RentsRepository(dbContext);
        }
        public IEnumerable<Rents> GetAllRents()
        {
            return _rentsRepository.GetAllRents();
        }

        public SelectBooksViewModel GetSelectBooksViewModel(List<Books> books, Students student)
        {
            var bookListModel = new SelectBooksViewModel();
            bookListModel.BooksList = new List<BooksList>();
            for (int i = 0; i < books.Count; i++)
            {
                var data = new BooksList();
                data.CheckBox = false;
                data.AuthorName = books[i].AuthorName;
                data.BookCount = books[i].BookCount;
                data.BookName = books[i].BookName;
                data.BookId = books[i].BookId;
                bookListModel.BooksList.Add(data);
            }
            bookListModel.StudentInformation = student;
            return bookListModel;
        }

        public void RentBooks(SelectBooksViewModel selectBooksViewModel)
        {
            _rentsRepository.RentBooks(selectBooksViewModel);
        }

        public void ReturnABook(int rentId, int bookId)
        {
            _rentsRepository.ReturnABook(rentId, bookId);
        }

    }
}
