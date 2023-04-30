using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Subcategory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
