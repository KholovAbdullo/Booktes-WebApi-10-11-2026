using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Genres
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }=null!;
    public List<Books> Books { get; set; }=[];
}
