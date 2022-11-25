namespace la_mia_pizzeria_model.Models.Repositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        public static List<Ingredient> Ingredients  = new List<Ingredient>();
        public List<Ingredient> All()
        {
            return Ingredients;
        }

        public void Create(Ingredient ingredientToCreate)
        {
            
        }

        public void Delete(Ingredient ingredientToDelete)
        {
            
        }

        public Ingredient GetById(int id)
        {
            
        }

        public List<Ingredient> GetList(List<int> ids)
        {
            
        }

        public void Update(Ingredient ingredientToUpdate)
        {
            
        }
    }
}
