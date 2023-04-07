using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Task_4.Models;
using Task_4.Repository.IRepository;
using Task_4.Utility;

namespace Task_4.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var ListOfAuthors = _unitOfWork.Author.GetAll(null,"Books");
            return View(ListOfAuthors);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Author author)
        {
            if (string.IsNullOrEmpty(author.SurName) || string.IsNullOrEmpty(author.Name) || string.IsNullOrEmpty(author.DateOfBirth.ToString()))
            {
                ModelState.AddModelError(nameof(author.SurName), "Прізвище не може бути пустим");
                ModelState.AddModelError(nameof(author.Name), "Ім`я не може бути пустим");
                ModelState.AddModelError(nameof(author.DateOfBirth), "Дата народження не може бути пустою");
            }
            if (author.DateOfBirth > DateTime.Now) { ModelState.AddModelError(nameof(author.DateOfBirth), "Дата народження не може бути більшою за поточну дату та час"); }
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Add(author);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);
            if (authorFromDbFirst == null)
            {
                return NotFound();
            }

            return View(authorFromDbFirst);
        }
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (string.IsNullOrEmpty(author.SurName) || string.IsNullOrEmpty(author.Name) || string.IsNullOrEmpty(author.DateOfBirth.ToString()))
            {
                ModelState.AddModelError(nameof(author.SurName), "Прізвище не може бути пустим");
                ModelState.AddModelError(nameof(author.Name), "Ім`я не може бути пустим");
                ModelState.AddModelError(nameof(author.DateOfBirth), "Дата народження не може бути пустою");
            }
            if (author.DateOfBirth > DateTime.Now) { ModelState.AddModelError(nameof(author.DateOfBirth), "Дата народження не може бути більшою за поточну дату та час"); }
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Update(author);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);
            if (authorFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Author.Remove(authorFromDbFirst);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Info(int? id)
        {
            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id, "Books");
            var GenreList = new SelectList(
                   new List<SelectListItem>
                   {
                        new SelectListItem { Text = $"{Genre.Genre_Novel}", Value = Genre.Genre_Novel},
                        new SelectListItem { Text = $"{Genre.Genre_Narrative}", Value = Genre.Genre_Narrative},
                        new SelectListItem { Text = $"{Genre.Genre_Poem}", Value = Genre.Genre_Poem},
                   }, "Value", "Text");

            ViewBag.GenreList = GenreList;
            return View(authorFromDbFirst);
        }
    }
}