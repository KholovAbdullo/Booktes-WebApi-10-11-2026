using Application.DTOs;
using Application.DTOs.Authors;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        return await service.AddAuthor(authorDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAuthor(int id,UpdateAuthorDto authorDto)
    {
        return await service.UpdateAuthor(id,authorDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthor(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorDto>> GetAuthor(int id)
    {
        return await service.GetAuthor(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        return await service.GetAuthors();
    }

    [HttpGet("statistic/{authorId}")]
    public async Task<ApiResponse<AuthorStatisticDto>> GetAuthorStatistic(int authorId)
    {
        return await service.GetAuthorStatistic(authorId);
    }
}
