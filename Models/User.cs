using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lav12_Async_KazanovAlexandr.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string? UserName { get; set; }
    }
}
