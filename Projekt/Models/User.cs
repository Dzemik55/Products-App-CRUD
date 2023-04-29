using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        public string Email { get; set; }
        public int Role_id { get; set; }
        [ForeignKey("Role_id")]
        public Role Roles { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
