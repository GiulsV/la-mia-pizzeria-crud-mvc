using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_model.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }
        public List<Pizza>? Pizze { get; set; }
    }
}
