using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Ingredient
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product_Ingredient> Product_Ingredients { get; set; }
    }
}
