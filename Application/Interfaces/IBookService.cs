using Application.DTOs.Books;
using Application.Responses;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto);
    Task<ApiResponse<bool>> UpdateBook(UpdateBookDto bookDto);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<BookDto>> GetBook(int id);
    Task<ApiResponse<List<BookDto>>> GetBooks();
    Task<ApiResponse<BookStatisticDto>> GetBookStatistic(int year);
}
