namespace la_mia_pizzeria_model.Models.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> All();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
