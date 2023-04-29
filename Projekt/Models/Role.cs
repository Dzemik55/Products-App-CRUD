using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
