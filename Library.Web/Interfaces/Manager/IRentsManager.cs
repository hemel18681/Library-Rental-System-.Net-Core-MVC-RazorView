using EF.Core.Repository.Interface.Manager;
using Library.Web.Models.DomainModels;
using Library.Web.Models.ViewModels;

namespace Library.Web.Interfaces.Manager
{
    public interface IRentsManager: ICommonManager<Rents>
    {
        IEnumerable<Rents> GetAllRents();
        void ReturnABook(int rentId, int bookId);
        SelectBooksViewModel GetSelectBooksViewModel(List<Books> books, Students student);
        void RentBooks(SelectBooksViewModel selectBooksViewModel);
    }
}
