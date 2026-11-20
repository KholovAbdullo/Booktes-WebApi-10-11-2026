using System.ComponentModel.DataAnnotations;
using Application.DTOs.Books;

namespace Application.DTOs.Authors;

public class AuthorDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Fullname { get; set; }=null!;
    [Required]
    [MaxLength(100)]
    public string Country { get; set; }=null!;

    [Range(1000,2026)]
    public int Birthyear {get; set; }
    public List<BookDto> Books { get; set; }=[]; 
}
