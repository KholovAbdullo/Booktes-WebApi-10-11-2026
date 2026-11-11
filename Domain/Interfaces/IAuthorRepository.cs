using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    Task<bool> AddAuthor(Authors author);
    Task<bool> UpdateAuthor(Authors author);
    Task<bool> DeleteAuthor(int id);
    Task<Authors> GetAuthor(int id);
    Task<List<Authors>> GetAuthors();

    Task<int> GetAuthorsAmount();
    Task<int> GetMinPublishedYearByAuthor(int authorId);
    Task<int> GetMaxPublishedYearByAuthor(int authorId);
}
