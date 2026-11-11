using Application.DTOs;
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
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        return await service.AddBook(bookDto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(UpdateBookDto bookDto)
    {
        return await service.UpdateBook(bookDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookDto>> GetBook(int id)
    {
        var res = await service.GetBook(id);

        if(res == null)
        {
            return null!;
        }

        return res;
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
