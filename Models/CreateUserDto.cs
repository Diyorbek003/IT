using System.ComponentModel.DataAnnotations;

namespace IT.Models
{
    public class CreateUserDto
    {
        [Required]
        public string? Name { get; set; }

        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        [Required]
        public int Phone { get; set; }

    }
}
