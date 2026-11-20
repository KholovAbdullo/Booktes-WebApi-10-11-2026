using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Books
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; }=null!;

    [Range(1000,2026)]
    public int Publishedyear { get; set; }

    [Range(0,int.MaxValue)]
    public int Totalcopies {get; set; }

    [Required]
    public int AuthorId { get; set; }
    public Authors Author { get; set; }=null!;

    [Required]
    public int GenreId { get; set; }
    public Genres Genre { get; set; }=null!;
}
