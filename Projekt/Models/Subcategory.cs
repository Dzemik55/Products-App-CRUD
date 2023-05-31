using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; } = null!;
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
