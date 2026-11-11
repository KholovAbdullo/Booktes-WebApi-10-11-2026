using Application.DTOs.Genres;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService,ILogger<IGenreService> logger) : ControllerBase
{
    private IGenreService service = genreService;

    private ILogger<IGenreService> loggerservice = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        loggerservice.LogInformation("Added new Genre!");
        var res = await service.AddGenre(genreDto);
        loggerservice.LogInformation("Genre added successfully!");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenre(UpdateGenreDto genreDto)
    {
        loggerservice.LogInformation("Update Genre!");
        var res = await service.UpdateGenre(genreDto);
        loggerservice.LogInformation("Genre Update successfully!");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        loggerservice.LogInformation("Delete genre ID: {id}",id);
        var res = await service.DeleteGenre(id);
        loggerservice.LogInformation("Genre ID:{id} delete successfully!", id);
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GenreDto>> GetGenre(int id)
    {
        loggerservice.LogInformation("Getting genre for ID: {Id}", id);
        return await service.GetGenre(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        loggerservice.LogInformation("Retrieving all genres!");
        return await service.GetGenres();
    }

    [HttpGet("statistic/{genreId}")]
    public async Task<ApiResponse<GenreStatisticDto>> GetGenreStatistic(int genreId)
    {
        loggerservice.LogInformation("Getting statistics for genre ID: {genreId}",genreId);
        return await service.GetGenreStatistic(genreId);
    }
}
