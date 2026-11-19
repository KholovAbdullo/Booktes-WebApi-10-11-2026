using Application.DTOs.Books;

namespace Application.DTOs.Authors;

public class AuthorDto
{
    public int Id { get; set; }
    public string Fullname { get; set; }=null!;
    public string Country { get; set; }=null!;
    public int Birthyear {get; set; }
    public List<BookDto> Books { get; set; }=[]; 
}
