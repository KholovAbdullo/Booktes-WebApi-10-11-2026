using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository):IGenreService
{
    private IGenreRepository genres = genreRepository;

    public async Task<ApiResponse<bool>> AddGenre(Genres genre)
    {
        var res = await genres.AddGenre(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var res = await genres.DeleteGenre(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<Genres>> GetGenre(int id)
    {
        var res = await genres.GetGenre(id);
        return res != null
        ? new ApiResponse<Genres>(HttpStatusCode.OK, "Genres id!",res)
        : new ApiResponse<Genres>(HttpStatusCode.NotFound, "Not Genres id!", res!);
    }

    public async Task<ApiResponse<List<Genres>>> GetGenres()
    {
        var res = await genres.GetGenres();
        return new ApiResponse<List<Genres>>(HttpStatusCode.OK, "ListGenres!", res);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(Genres genre)
    {
        var res = await genres.UpdateGenre(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!",res);
    }

}
