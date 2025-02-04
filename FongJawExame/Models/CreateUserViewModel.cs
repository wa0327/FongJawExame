using System.ComponentModel.DataAnnotations;

namespace FongJawWeb.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
