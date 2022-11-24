using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_model.Models.Form;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<Pizza> Pizze = db.Pizze.Include("Category").ToList();
            return View(Pizze);
        }

        public IActionResult Detail(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
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
            formData.Ingredients =new List<SelectListItem>();

            List<Ingredient>ingredientList = db.Ingredients.ToList();

            foreach (Ingredient ingredient in ingredientList)
            {
                SelectListItem listItem = new SelectListItem(ingredient.Name, ingredient.Id.ToString());
                formData.Ingredients.Add(listItem);
            }
            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> ingredientList =db.Ingredients.ToList();

                foreach (Ingredient ingredient in ingredientList)
                {
                    SelectListItem listItem = new SelectListItem(ingredient.Name, ingredient.Id.ToString());
                    formData.Ingredients.Add(listItem);
                }

                return View(formData);
            }

            formData.Pizza.Ingredients = new List<Ingredient>();

            foreach(int ingredientId in formData.SelectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                formData.Pizza.Ingredients.Add(ingredient);
            }

            db.Pizze.Add(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //UPDATE - MODIFICA
        public IActionResult Update(int id)
        {
            PizzaForm formData = new PizzaForm();
            Pizza pizza = db.Pizze.Where(p => p.Id == id).Include(p => p.Ingredients).FirstOrDefault();

            if (pizza == null)
                return NotFound();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredientList = db.Ingredients.ToList();

            foreach (Ingredient ingredient in ingredientList)
            {
                SelectListItem listitem = new SelectListItem(ingredient.Name, ingredient.Id.ToString(), formData.Pizza.Ingredients.Any(i => i.Id == ingredient.Id));
                formData.Ingredients.Add(listitem);
            }
            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm formData) 
        {
            if (!ModelState.IsValid)
            {
                formData.Pizza.Id = id;
                formData.Categories = db.Categories.ToList();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> ingredientList = db.Ingredients.ToList();

                foreach (Ingredient ingredient in ingredientList)
                {
                    SelectListItem listItem = new SelectListItem(ingredient.Name, ingredient.Id.ToString());
                    formData.Ingredients.Add(listItem);
                }

                return View(formData);
            }

            Pizza pizzaItem =db.Pizze.Where(pizza => pizza.Id == id).Include(p => p.Ingredients).FirstOrDefault();

            if (pizzaItem != null) 
            {
                return NotFound();
            }
            pizzaItem.Name = formData.Pizza.Name; 
            pizzaItem.Description= formData.Pizza.Description;
            pizzaItem.Image = formData.Pizza.Image;
            pizzaItem.CategoryId = formData.Pizza.CategoryId;

            pizzaItem.Ingredients.Clear();

            if (formData.SelectedIngredients == null)
            {
                formData.SelectedIngredients = new List<int>();
            }

            foreach (int ingredientId in formData.SelectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizzaItem.Ingredients.Add(ingredient);
            }

            db.SaveChanges();

            return RedirectToAction("Detail", new { id = pizzaItem.Id });
        }
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
