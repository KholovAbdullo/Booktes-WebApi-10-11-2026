using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Genres;

public class UpdateGenreDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }=null!;
}
