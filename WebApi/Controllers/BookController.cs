using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private IBookService service = bookService;
    
    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(Books book)
    {
        return await service.AddBook(book);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(Books book)
    {
        return await service.UpdateBook(book);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Books>> GetBook(int id)
    {
        var res = await service.GetBook(id);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Books>>> GetBooks()
    {
        return await service.GetBooks();
    }
}
