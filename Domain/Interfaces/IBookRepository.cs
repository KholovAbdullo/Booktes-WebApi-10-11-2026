using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<bool> AddBook(Books book);
    Task<bool> UpdateBook(Books book);
    Task<bool> DeleteBook(int id);
    Task<Books> GetBook(int id);
    Task<List<Books>> GetBooks();
}
