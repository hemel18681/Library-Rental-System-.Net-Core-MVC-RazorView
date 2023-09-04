using EF.Core.Repository.Interface.Repository;
using Library.Web.Models.DomainModels;

namespace Library.Web.Interfaces.Repository
{
    public interface IRentsRepository: ICommonRepository<Rents>
    {
        IEnumerable<Rents> GetAllRents();
        void ReturnABook(int rentId, int bookId);
    }
}
