
using la_mia_pizzeria_model.Validator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_model.Models
{
    public class Pizza
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "obbligatorio")]
        [StringLength(50, ErrorMessage = "Meno di 50 caratteri")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "obbligatoria")]
        [StringLength(250, ErrorMessage = "Meno di 250 caratteri")]
        [DescriptionLength]
        public string Description { get; set; }

        [Required(ErrorMessage = "obbligatoria")]
        public string Image { get; set; }

        [Range(1, 100, ErrorMessage = "Prezzo compreso tra 1 e 100")]
        [Required(ErrorMessage = "obbligatorio")]
        public double Price { get; set; }

        //costruttore vuoto
        public Pizza(){

        }

        public Pizza(string name, string description, string image, double price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}