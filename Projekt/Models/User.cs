using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Pseudonim { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        public string Email { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Roles { get; } = null!;
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
