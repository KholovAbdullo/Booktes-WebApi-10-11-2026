namespace Application.DTOs.Books;

public class UpdateBookDto
{
    public string Title { get; set; }=null!;
    public int Publishedyear { get; set; }
    public int Totalcopies {get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}
