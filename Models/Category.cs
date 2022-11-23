using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_model.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obbligatorio")]
        [StringLength(30, ErrorMessage = "Non può avere più di 30 caratteri")]
        public string Name { get; set; }
        public List<Pizza>? Pizze { get; set; }
    }
}
