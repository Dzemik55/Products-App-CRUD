using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Subcategory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Category_id { get; set; }
        [ForeignKey("Category_id")]
        public Category Categories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
