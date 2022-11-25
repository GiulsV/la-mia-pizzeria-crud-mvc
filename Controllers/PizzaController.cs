using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_model.Models.Form;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;
using la_mia_pizzeria_model.Models.Repositories;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;
        IDbPizzaRepository pizzaRepository;

        public PizzaController(IDbPizzaRepository _pizzaRepository) : base()
        {
            // db = new PizzeriaDbContext();
            pizzaRepository = _pizzaRepository;
        }

        //INDEX
        public IActionResult Index()
        {
            List<Pizza> listaPizze = pizzaRepository.All();
            return View(listaPizze);
        }

        //DETAIL
        public IActionResult Detail(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);
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

            List<Ingredient> ingredientList = db.Ingredients.ToList();

            foreach (Ingredient ingredient in ingredientList)
            {
                formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
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

                List<Ingredient> ingredientList = db.Ingredients.ToList();

                foreach (Ingredient ingredient in ingredientList)
                {
                    formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
                }

                return View(formData);
            }

            pizzaRepository.Create(formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //UPDATE - MODIFICA
        public IActionResult Update(int id)
        {

            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
                return NotFound();

            PizzaForm formData = new PizzaForm();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredientList = db.Ingredients.ToList();


            foreach (Ingredient ingredient in ingredientList)
            {
                formData.Ingredients.Add(new SelectListItem(
                    ingredient.Name,
                    ingredient.Id.ToString(),
                    pizza.Ingredients.Any(i => i.Id == ingredient.Id)
                    ));
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
                    formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
                }

                return View(formData);
            }

            Pizza pizzaItem = pizzaRepository.GetById(id);

            if (pizzaItem == null) 
            {
                return NotFound();
            }

            pizzaRepository.Update(pizzaItem, formData.Pizza, formData.SelectedIngredients);

            //pizzaItem.Name = formData.Pizza.Name; 
            //pizzaItem.Description= formData.Pizza.Description;
            //pizzaItem.Image = formData.Pizza.Image;
            //pizzaItem.CategoryId = formData.Pizza.CategoryId;

            //pizzaItem.Ingredients.Clear();

            //if (formData.SelectedIngredients == null)
            //{
            //    formData.SelectedIngredients = new List<int>();
            //}

            //foreach (int ingredientId in formData.SelectedIngredients)
            //{
            //    Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
            //    pizzaItem.Ingredients.Add(ingredient);
            //}

            //db.SaveChanges();

            return RedirectToAction("Detail", new { id = pizzaItem.Id });
        }

        //DELETE - CANCELLA

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            pizzaRepository.Delete(pizza);

            return RedirectToAction("Index");
        }
    }
}
