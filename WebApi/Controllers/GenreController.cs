using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private IGenreService service = genreService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(Genres genre)
    {
        return await service.AddGenre(genre);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenre(Genres genre)
    {
        return await service.UpdateGenre(genre);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        return await service.DeleteGenre(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Genres>> GetGenre(int id)
    {
        var res = await service.GetGenre(id);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Genres>>> GetGenres()
    {
        return await service.GetGenres();
    }
}
