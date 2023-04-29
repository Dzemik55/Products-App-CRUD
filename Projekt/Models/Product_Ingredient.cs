using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Product_Ingredient
    {
        public int Product_id { get; set; }
        public Product Product { get; set; }
        public int Ingredient_id { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
