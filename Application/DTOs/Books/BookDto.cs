using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Books;

public class BookDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }=null!;
    [Range(1000,2026)]
    public int Publishedyear { get; set; }

    [Range(0,int.MaxValue)]
    public int Totalcopies {get; set; }
    [Required]
    public int AuthorId { get; set; }
    [Required]
    public int GenreId { get; set; }
}
