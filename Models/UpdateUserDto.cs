using System.ComponentModel.DataAnnotations;

namespace IT.Models
{
    public class UpdateUserDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }
    }
}
