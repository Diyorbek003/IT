using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IT.Models;

public class CreateAdminDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    [Required]
    public int Phone { get; set; }
}
