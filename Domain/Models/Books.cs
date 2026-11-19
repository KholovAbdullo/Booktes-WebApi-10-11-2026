namespace Domain.Models;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }=null!;
    public int Publishedyear { get; set; }
    public int Totalcopies {get; set; }

    public int AuthorId { get; set; }
    public Authors Author { get; set; }=null!;

    public int GenreId { get; set; }
    public Genres Genre { get; set; }=null!;
}
