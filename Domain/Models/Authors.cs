using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Authors
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

    public List<Books> Books { get; set; }=[];
}
