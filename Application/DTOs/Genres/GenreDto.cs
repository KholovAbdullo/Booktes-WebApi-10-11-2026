using Application.DTOs.Books;

namespace Application.DTOs.Genres;

public class GenreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<BookDto> Books { get; set; }=[];
}
