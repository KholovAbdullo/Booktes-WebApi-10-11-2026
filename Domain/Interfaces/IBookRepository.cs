using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<bool> AddBook(Books book);
    Task<bool> UpdateBook(int id,Books book);
    Task<bool> DeleteBook(int id);
    Task<Books> GetBook(int id);
    Task<List<Books>> GetBooks();

    Task<int> GetBookAmount();
    Task<int> GetAmountByPublishedYear(int year);
}
