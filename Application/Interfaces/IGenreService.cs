
using Application.DTOs;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto);
    Task<ApiResponse<bool>> UpdateGenre(UpdateGenreDto genreDto);
    Task<ApiResponse<bool>> DeleteGenre(int id);
    Task<ApiResponse<GenreDto>> GetGenre(int id);
    Task<ApiResponse<List<GenreDto>>> GetGenres();
    Task<ApiResponse<GenreStatisticDto>> GetGenreStatistic(int genreId);
}
