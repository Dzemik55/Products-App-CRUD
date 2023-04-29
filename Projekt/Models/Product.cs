using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Subcategory_id { get; set; }
        [ForeignKey("Subcategory_id")]
        public Subcategory Subcategories { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public User Users { get; set; }

        public ICollection<Product_Ingredient> Product_Ingredients { get; set; }
    }
}
