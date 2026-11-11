using Application.DTOs.Books;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService,ILogger<IBookService> logger) : ControllerBase
{
    private IBookService service = bookService;

    private ILogger<IBookService> loggerservice = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        loggerservice.LogInformation("Added new Book!");
        var res = await service.AddBook(bookDto);
        loggerservice.LogInformation("Book added successfully!");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(UpdateBookDto bookDto)
    {
        loggerservice.LogInformation("Update Book!");
        var res = await service.UpdateBook(bookDto);
        loggerservice.LogInformation("Book Update successfully!");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        loggerservice.LogInformation("Delete book ID: {id}",id);
        var res = await service.DeleteBook(id);
        loggerservice.LogInformation("Book ID:{id} delete successfully!",id);
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookDto>> GetBook(int id)
    {
        loggerservice.LogInformation("Getting book for ID: {Id}", id);
        return await service.GetBook(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        loggerservice.LogInformation("Getting all Books!");
        return await service.GetBooks();
    }

    [HttpGet("statistic/{year}")]
    public async Task<ApiResponse<BookStatisticDto>> GetBookStatistic(int year)
    {
        loggerservice.LogInformation("Getting statistics for book Year: {year}",year);
        return await service.GetBookStatistic(year);
    }
}
