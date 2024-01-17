using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller

    {

        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View(_appDbContext.Books.ToList());
        }

        [HttpGet]
        public IActionResult CreateTables()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTables(Books Book)
        {
            // Make sure 'ID' is not set explicitly here.
            // Assuming 'ID' is the identity column in your 'Books' table.
            // Let the database generate the ID automatically.

            _appDbContext.Books.Add(Book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Tables");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var editBook = _appDbContext.Books.Find(Id);
            if (editBook != null)
            {
                return View(editBook);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Books updatedBook)
        {
            var existingBook = _appDbContext.Books.Find(updatedBook.BookId);

            if (existingBook == null)
            {
                return NotFound();
            }

            // Update the properties of the existing book with the new values
            existingBook.BookName = updatedBook.BookName;
            existingBook.AuthorName = updatedBook.AuthorName;

            // Save the changes to the database
            _appDbContext.SaveChanges();

            return RedirectToAction("Tables");
        }

    }
}
