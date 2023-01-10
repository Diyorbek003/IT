using System.ComponentModel.DataAnnotations;

namespace IT.Models
{
    public class CreateUserDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Phone { get; set; }

    }
}
