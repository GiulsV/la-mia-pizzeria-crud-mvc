using la_mia_pizzeria_model.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Data
{
    public class PizzeriaDbContext : DbContext
    {
        private static PizzeriaDbContext _instance;
        public static PizzeriaDbContext Instance
        {
            get { return _instance ?? (_instance = new PizzeriaDbContext()); }
        }
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizzeriamodel;Integrated Security=True;Encrypt=false;");

        }
    }
}