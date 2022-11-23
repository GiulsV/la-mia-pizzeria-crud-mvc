using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_model.Controllers
{
    public class CategoryController : Controller
    {
        PizzeriaDbContext db;

        public CategoryController() : base()
        {
            db = new PizzeriaDbContext();
        }

        //INDEX
        public IActionResult Index()
        {
            List<Category> listCategories = db.Categories.ToList();
            return View(listCategories);
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoria)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            db.Categories.Add(categoria);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //UPDATE
        public IActionResult Update(int id)
        {
            Category categoria = db.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Category categoria)
        {

            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            db.Categories.Update(categoria);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //DELETE
        //public IActionResult Delete(int id) { }
    }
}
