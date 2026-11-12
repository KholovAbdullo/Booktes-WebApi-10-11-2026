using Application.DTOs.Books;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private IBookService service = bookService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        return await service.AddBook(bookDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateBook(int id,UpdateBookDto bookDto)
    {
        return await service.UpdateBook(id,bookDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookDto>> GetBook(int id)
    {
        return await service.GetBook(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        return await service.GetBooks();
    }

    [HttpGet("statistic/{year}")]
    public async Task<ApiResponse<BookStatisticDto>> GetBookStatistic(int year)
    {
        return await service.GetBookStatistic(year);
    }
}
