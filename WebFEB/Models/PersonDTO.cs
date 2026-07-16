using System.ComponentModel.DataAnnotations;

namespace WebFEB.Models;

public class PersonDTO
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public double Credit { get; set; }
}
