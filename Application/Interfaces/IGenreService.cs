using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<bool>> AddGenre(Genres genre);
    Task<ApiResponse<bool>> UpdateGenre(Genres genre);
    Task<ApiResponse<bool>> DeleteGenre(int id);
    Task<ApiResponse<Genres>> GetGenre(int id);
    Task<ApiResponse<List<Genres>>> GetGenres();
}
