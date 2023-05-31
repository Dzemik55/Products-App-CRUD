using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Podkategoria")]
        public int SubcategoryId { get; set; }
        [ForeignKey("SubcategoryId")]
        public Subcategory? Subcategories { get; }
        [DisplayName("Dodane przez użytkownika")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? Users { get; }

        public ICollection<Product_Ingredient> Product_Ingredients { get; } = new List<Product_Ingredient>();
    }
}
