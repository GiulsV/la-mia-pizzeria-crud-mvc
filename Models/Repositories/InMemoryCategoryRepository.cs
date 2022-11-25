namespace la_mia_pizzeria_model.Models.Repositories
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        public static List<Category> Categories = new List<Category>();
        public List<Category> All()
        {
            return Categories;
        }

        public void Create(Category categoryToCreate)
        {
            
        }

        public void Delete(Category categoryToDelete)
        {
            
        }

        public Category GetById(int id)
        {
            
        }

        public void Update(Category categoryToUpdate)
        {
            
        }
    }
}
