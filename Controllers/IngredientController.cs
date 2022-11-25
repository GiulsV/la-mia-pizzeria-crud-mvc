using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Controllers
{
    public class IngredientController : Controller
    {
        DbIngredientRepository ingredientRepository;

        public IngredientController() : base()
        {
            ingredientRepository = new DbIngredientRepository();
        }

        //INDEX
        public IActionResult Index()
        {
            List<Ingredient> listIngredient = ingredientRepository.All();
            return View(listIngredient);
        }


        //CREATE
        public IActionResult Create()
        {
            Ingredient ingredient = new Ingredient();
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingrediente)
        {
            if (!ModelState.IsValid)
            {
                return View(ingrediente);

            }

            ingredientRepository.Create(ingrediente);

            return RedirectToAction("Index");
        }


        //UPDATE
        public IActionResult Update(int id)
        {
            Ingredient ingrediente = ingredientRepository.GetById(id);

            if (ingrediente == null)
                return NotFound();

            return View(ingrediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Ingredient ingrediente)
        {

            if (!ModelState.IsValid)
            {
                return View(ingrediente);
            }
            ingredientRepository.Update(ingrediente);

            return RedirectToAction("Index");
        }


        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Ingredient ingrediente = ingredientRepository.GetById(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            ingredientRepository.Delete(ingrediente);

            return RedirectToAction("Index");
        }
    }
}
