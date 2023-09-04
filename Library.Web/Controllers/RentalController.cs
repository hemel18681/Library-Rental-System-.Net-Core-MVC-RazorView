using Library.Web.Interfaces;
using Library.Web.Interfaces.Manager;
using Library.Web.Interfaces.Repository;
using Library.Web.Manager;
using Library.Web.Models;
using Library.Web.Models.DomainModels;
using Library.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Web.Controllers
{
    public class RentalController : Controller
    {
        private IRentsManager _rentsManager;
        private IBooksManager _booksManager;
        private IStudentsManager _studentsManager;

        public RentalController(IRentsManager rentsManager, IBooksManager booksManager, IStudentsManager studentsManager)
        {
            _rentsManager = rentsManager;
            _booksManager = booksManager;
            _studentsManager = studentsManager;
        }

        public IActionResult Index()
        {
            try
            {
                var rents = _rentsManager.GetAllRents();
                return View("Index", rents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult SelectStudent()
        {
            try
            {
                var students = _studentsManager.GetAll().ToList();
                return View("SelectStudent", students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult SelectBooks(int studentId)
        {
            try
            {
                var books = _booksManager.GetAll().Where(b => b.BookCount > 0).ToList();
                var student = _studentsManager.GetFirstOrDefault(x => x.StudentId == studentId);
                var bookListView = _rentsManager.GetSelectBooksViewModel(books, student);
                return View("SelectBooks", bookListView);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult RentABook([FromForm]SelectBooksViewModel viewModel)
        {

            try
            {
                _rentsManager.RentBooks(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult ReturnABook(int rentId, int bookId)
        {
            try
            {
                _rentsManager.ReturnABook(rentId, bookId);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
