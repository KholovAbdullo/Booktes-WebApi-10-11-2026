using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository):IGenreService
{
    private IGenreRepository genres = genreRepository;

    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        var genre = new Genres()
        {
            Name=genreDto.Name
        };

        var res = await genres.AddGenre(genre);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var res = await genres.DeleteGenre(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!", res); 
    }

    public async Task<ApiResponse<GenreDto>> GetGenre(int id)
    {
        var res = await genres.GetGenre(id);

        if(res == null)
        {
            return new ApiResponse<GenreDto>(HttpStatusCode.NotFound, "Genre not faund", null!);
        }

        var genre = new GenreDto()
        {
            Id=res.Id,
            Name=res.Name
        };

        return new ApiResponse<GenreDto>(HttpStatusCode.OK, "Genre!", genre);
    }

    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        var res = await genres.GetGenres();

        var genre = res.Select(g=>new GenreDto
        {
            Id=g.Id,
            Name=g.Name
        }).ToList();

        return new ApiResponse<List<GenreDto>>(HttpStatusCode.OK, "List Genres!", genre);
    }

    public async Task<ApiResponse<GenreStatisticDto>> GetGenreStatistic(int genreId)
    {
        var res = new GenreStatisticDto();

        res.GenresAmount=await genres.GetGenresAmount();
        res.MaxPublishedYear=await genres.GetMaxPublishedYearByGenre(genreId);
        res.MinPublishedYear=await genres.GetMinPublishedYearByGenre(genreId);
        res.BooksAmount=await genres.GetAmountByGenre(genreId);

        return new ApiResponse<GenreStatisticDto>(HttpStatusCode.OK, "Genre Statistic!", res);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(UpdateGenreDto genreDto)
    {
        var genre = new Genres()
        {
            Id=genreDto.Id,
            Name=genreDto.Name
        };

        var res = await genres.UpdateGenre(genre);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }

}
