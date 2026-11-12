namespace Application.DTOs.Authors;

public class UpdateAuthorDto
{
    public string Fullname { get; set; }=null!;
    public string Country { get; set; }=null!;
    public int Birthyear {get; set; }
}
