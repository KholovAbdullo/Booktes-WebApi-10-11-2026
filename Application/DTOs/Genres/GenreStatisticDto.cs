namespace Application.DTOs.Genres;

public class GenreStatisticDto
{
    public int GenresAmount { get; set; }
    public int MinPublishedYear { get; set; }
    public int MaxPublishedYear { get; set; }
    public int BooksAmount { get; set; }
}
