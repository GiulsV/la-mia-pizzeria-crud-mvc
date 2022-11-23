
using la_mia_pizzeria_model.Validator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace la_mia_pizzeria_model.Models
{
    public class Pizza
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }


        //relazione 1 a n con Category ed è la vera e propria chiave esterna
        public int CategoryId { get; set; }

        //relazione 1 a n con Category l'istanza del record nelle query
        public Category? Category { get; set; }


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