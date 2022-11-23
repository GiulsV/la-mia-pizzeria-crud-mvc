using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_model.Models.Form;
using Microsoft.CodeAnalysis;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;

        public PizzaController() : base()
        {
            db = new PizzeriaDbContext();
        }
        public IActionResult Index()
        {
            List<Pizza> Pizze = db.Pizze.Include(p => p.Category).ToList();
            return View(Pizze);
        }

        public IActionResult Detail(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).Include("Category").FirstOrDefault();
            if (pizza == null)
                return View("Errore", "Pizza non trovata");

            return View(pizza);

        }

        //CREATE
        public IActionResult Create()
        {
            PizzaForm formData = new PizzaForm();

            formData.Pizza = new Pizza();
            formData.Categories = db.Categories.ToList();

            return View(formData);
        }

        [HttpPost]
        public IActionResult Create(PizzaForm formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            db.Pizze.Add(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //UPDATE - MODIFICA
        public IActionResult Update(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();

            PizzaForm formData = new PizzaForm();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm formData) 
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            formData.Pizza.Id = id;
            db.Pizze.Update(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult Update(int id, Pizza formData)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    Pizza pizza = db.Pizze.Where(pizza => pizza.Id == id).Include("Category").FirstOrDefault();

        //    if (pizza == null)
        //    {
        //        return NotFound();
        //    }

        //    pizza.Name = formData.Name;
        //    pizza.Description = formData.Description;
        //    pizza.Image = formData.Image;

        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //DELETE - CANCELLA

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            db.Pizze.Remove(pizza);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
