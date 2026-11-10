using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBook(Books book);
    Task<ApiResponse<bool>> UpdateBook(Books book);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<Books>> GetBook(int id);
    Task<ApiResponse<List<Books>>> GetBooks();
}
