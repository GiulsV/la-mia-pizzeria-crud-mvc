namespace la_mia_pizzeria_model.Models.Repositories
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        public static List<Pizza> Pizze = new List<Pizza>();
        public List<Pizza> All()
        {
            return Pizze;
        }

        public void Create(Pizza pizzaToCreate, List<int> SelectedIngredients)
        {

            pizzaToCreate.Id = Pizze.Count;
            pizzaToCreate.Category = new Category() { Id = 1, Name = "Fake cateogry" };


            pizzaToCreate.Ingredients = new List<Ingredient>();

            IngredientsToPizza(pizzaToCreate, SelectedIngredients);


            Pizze.Add(pizzaToCreate);
        }

        public void Delete(Pizza pizzaToDelete)
        {
            Pizze.Remove(pizzaToDelete);
        }

        public Pizza GetById(int id)
        {
            Pizza pizzaToId = Pizze.Where(pizzaToId => pizzaToId.Id == id).FirstOrDefault();

            pizzaToId.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            return pizzaToId;
        }

        public void Update(Pizza pizzaToUpdate, Pizza formData, List<int>? SelectedIngredients)
        {
            pizzaToUpdate = formData;
            pizzaToUpdate.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            pizzaToUpdate.Ingredients = new List<Ingredient>();

            IngredientsToPizza(pizzaToUpdate, SelectedIngredients);
        }
        private static void IngredientsToPizza(Pizza pizza, List<int> SelectedIngredients)
        {
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            foreach (int ingredientId in SelectedIngredients)
            {
                pizza.Ingredients.Add(new Ingredient() { Id = ingredientId, Name = "Fake ingredient title " + ingredientId });
            }
        }
    }
}

