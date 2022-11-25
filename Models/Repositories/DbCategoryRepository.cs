using la_mia_pizzeria_model.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Models.Repositories
{
    public class DbCategoryRepository : ICategoryRepository
    {
        PizzeriaDbContext db;
        public DbCategoryRepository()
        {
            db = PizzeriaDbContext.Instance;
        }
        public List<Category> All()
        {
            return db.Categories.Include("Pizze").ToList();
        }
        public Category GetById(int id)
        {
            return db.Categories.Where(c => c.Id == id).Include("Pizze").FirstOrDefault();
        }
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
