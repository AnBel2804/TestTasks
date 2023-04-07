using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_4.Models;
using Task_4.Repository.IRepository;
using Task_4.Utility;

namespace Task_4.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Add()
        {
            Book book = new Book();
            book.Title = Request.Form["Title"];
            book.Genre = Request.Form["Genre"];
            book.NumberOfPages = int.Parse(Request.Form["NumberOfPages"]);
            int authorID = int.Parse(Request.Form["Author"]);
            Author authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == authorID);
            book.Author = authorFromDbFirst;

            if (book.Title != null && book.Genre != null && book.NumberOfPages > 0)
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.Save();
            }

            return RedirectToAction("Info", "Author", authorFromDbFirst);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var GenreList = new SelectList(
               new List<SelectListItem>
               {
                                new SelectListItem { Text = $"{Genre.Genre_Novel}", Value = Genre.Genre_Novel},
                                new SelectListItem { Text = $"{Genre.Genre_Narrative}", Value = Genre.Genre_Narrative},
                                new SelectListItem { Text = $"{Genre.Genre_Poem}", Value = Genre.Genre_Poem},
               }, "Value", "Text");
            ViewBag.GenreList = GenreList;

            var bookFromDbFirst = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == id, "Author");
            if (bookFromDbFirst == null)
            {
                return NotFound();
            }

            return View(bookFromDbFirst);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Genre) || string.IsNullOrEmpty(Convert.ToString(book.NumberOfPages)))
            {
                ModelState.AddModelError(nameof(book.Title), "Назва не може бути пустою");
                ModelState.AddModelError(nameof(book.Genre), "Жанр не може бути пустим");
                ModelState.AddModelError(nameof(book.NumberOfPages), "Кількість сторінок не може бути пустою");
            }
            if (ModelState.IsValid)
            {
                Author authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == book.Author.Id);
                book.Author = authorFromDbFirst;
                _unitOfWork.Book.Update(book);
                _unitOfWork.Save();
                return RedirectToAction("Info", "Author", book.Author);
            }
            return View(book);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDbFirst = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == id);
            if (bookFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(bookFromDbFirst);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Author");
        }
    }
}
