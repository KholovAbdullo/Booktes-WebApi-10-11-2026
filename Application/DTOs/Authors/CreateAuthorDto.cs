using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Authors;

public class CreateAuthorDto
{
    [Required]
    [MaxLength(100)]
    public string Fullname { get; set; }=null!;
    [Required]
    [MaxLength(100)]
    public string Country { get; set; }=null!;
    [Range(1000,2026)]
    public int Birthyear {get; set; }
}
