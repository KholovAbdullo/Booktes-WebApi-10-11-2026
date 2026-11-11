using Application.DTOs;
using Application.DTOs.Authors;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService,ILogger<IAuthorService> logger) : ControllerBase
{
    private IAuthorService service = authorService;
    private ILogger<IAuthorService> loggerservic = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        loggerservic.LogInformation("Added new author!");
        var res = await service.AddAuthor(authorDto);
        loggerservic.LogInformation("Author added successfully!");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(UpdateAuthorDto authorDto)
    {
        loggerservic.LogInformation("Update author!");
        var res = await service.UpdateAuthor(authorDto);
        loggerservic.LogInformation("Author Update successfully!");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        loggerservic.LogInformation("Delete author ID: {id}",id);
        var res = await service.DeleteAuthor(id);
        loggerservic.LogInformation("Author ID:{id} delete successfully!",id);
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorDto>> GetAuthor(int id)
    {
        loggerservic.LogInformation("Getting author for ID: {Id}", id);
        return await service.GetAuthor(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        loggerservic.LogInformation("Getting all authors!");
        return await service.GetAuthors();
    }

    [HttpGet("statistic/{authorId}")]
    public async Task<ApiResponse<AuthorStatisticDto>> GetAuthorStatistic(int authorId)
    {
        loggerservic.LogInformation("Getting statistics for author ID: {AuthorId}",authorId); 
        return await service.GetAuthorStatistic(authorId);
    }
}
