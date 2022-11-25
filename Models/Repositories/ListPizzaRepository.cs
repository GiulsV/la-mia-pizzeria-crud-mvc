using Azure;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_model.Models.Repositories
{
    public class ListPizzaRepository : IDbPizzaRepository
    {
        public static List<Pizza> Pizza = new List<Pizza>();

        public ListPizzaRepository()
        {
            //non lo possiamo fare perchè ognu nuova possibile istanza ci cancella la lista
            //Posts = new List<Post>();
        }

        public List<Pizza> All()
        {
            return Pizza;
        }

        //CREATE
        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            //simuliamo la primary key
            pizza.Id = Pizza.Count;
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            //simulazione da implentare con ListTagRepository
            pizza.Ingredients = new List<Ingredient>();

            IngredientToPizza(pizza, selectedIngredients);
            //fine simulazione

            Pizza.Add(pizza);
        }

        private static void IngredientToPizza(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            foreach (int ingId in selectedIngredients)
            {
                pizza.Ingredients.Add(new Ingredient() { Id = ingId, Name = "Fake tag " + ingId });
            }
        }

        //DELETE
        public void Delete(Pizza pizza)
        {
            Pizza.Remove(pizza);
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };
            return pizza;
        }

        //UPDATE
        public void Update(Pizza pizza, Pizza formData, List<int>? selectedIngredients)
        {
            pizza = formData;
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            pizza.Ingredients = new List<Ingredient>();

            //simulazione da implentare con ListTagRepository

            IngredientToPizza(pizza, selectedIngredients);
            //fine simulazione


        }

    }
}
