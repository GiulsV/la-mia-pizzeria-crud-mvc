using la_mia_pizzeria_model.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_model.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizzeriamodel;Integrated Security=True;Encrypt=false;");

        }
    }
}