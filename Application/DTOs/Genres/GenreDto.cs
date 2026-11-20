using System.ComponentModel.DataAnnotations;
using Application.DTOs.Books;

namespace Application.DTOs.Genres;

public class GenreDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    public List<BookDto> Books { get; set; }=[];
}
