using Application.DTOs.Genres;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private IGenreService service = genreService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        return await service.AddGenre(genreDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGenre(int id,UpdateGenreDto genreDto)
    {
        return await service.UpdateGenre(id,genreDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        return await service.DeleteGenre(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GenreDto>> GetGenre(int id)
    {
        return await service.GetGenre(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        return await service.GetGenres();
    }

    [HttpGet("statistic/{genreId}")]
    public async Task<ApiResponse<GenreStatisticDto>> GetGenreStatistic(int genreId)
    {
        return await service.GetGenreStatistic(genreId);
    }
}
