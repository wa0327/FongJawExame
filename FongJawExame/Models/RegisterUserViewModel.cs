using System.ComponentModel.DataAnnotations;

namespace FongJawExame.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
