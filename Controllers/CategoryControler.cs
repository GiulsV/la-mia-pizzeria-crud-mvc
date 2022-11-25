using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Controllers
{
    public class CategoryController : Controller
    {
        DbCategoryRepository categoryRepository;

        public CategoryController() : base()
        {
            categoryRepository = new DbCategoryRepository();
        }

        //INDEX
        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.All();
            return View(categories);
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            Category categoria = categoryRepository.GetById(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);

        }

        //CREATE
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoria)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            categoryRepository.Create(categoria);

            return RedirectToAction("Index");
        }

        //UPDATE
        public IActionResult Update(int id)
        {
            Category category = categoryRepository.GetById(id);
            if (category == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Category categoria)
        {

            if (!ModelState.IsValid)
            {
                return View(categoria);
            }
            categoryRepository.Update(categoria);

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category categoria = categoryRepository.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }
            categoryRepository.Delete(categoria);

            return RedirectToAction("Index");
        }
    }
}
