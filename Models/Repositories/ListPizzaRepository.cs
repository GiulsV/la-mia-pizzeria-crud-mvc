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

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            //simuliamo la primary key
            pizza.Id = Pizza.Count;
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            //simulazione da implentare con ListTagRepository
            pizza.Ingredients = new List<Ingredient>();

            TagToPost(pizza, selectedIngredients);
            //fine simulazione

            Pizza.Add(pizza);
        }

        private static void TagToPost(Pizza post, List<int> selectedIngredients)
        {
            post.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            foreach (int ingId in selectedIngredients)
            {
                post.Ingredients.Add(new Ingredient() { Id = ingId, Name = "Fake tag " + ingId });
            }
        }

        public void Delete(Pizza post)
        {
            Pizza.Remove(post);
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizza.Where(post => post.Id == id).FirstOrDefault();

            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };
            return pizza;
        }

        public void Update(Pizza pizza, Pizza formData, List<int>? selectedIngredients)
        {
            pizza = formData;
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            pizza.Ingredients = new List<Ingredient>();

            //simulazione da implentare con ListTagRepository

            TagToPost(pizza, selectedIngredients);
            //fine simulazione


        }

    }
}
