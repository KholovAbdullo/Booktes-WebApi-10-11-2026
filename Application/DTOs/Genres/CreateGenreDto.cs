using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Genres;

public class CreateGenreDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }=null!;
}
