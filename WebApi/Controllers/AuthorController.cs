using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(Authors author)
    {
        return await service.AddAuthor(author);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(Authors author)
    {
        return await service.UpdateAuthor(author);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthor(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Authors>> GetAuthor(int id)
    {
        var res = await service.GetAuthor(id);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Authors>>> GetAuthors()
    {
        return await service.GetAuthors();
    }
}
