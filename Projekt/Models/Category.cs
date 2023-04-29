using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
