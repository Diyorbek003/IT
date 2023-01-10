using System.ComponentModel.DataAnnotations;

namespace IT.Models
{
    public class CreateUserDto
    {
        public int Id { get; set; }    
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        

    }
}
