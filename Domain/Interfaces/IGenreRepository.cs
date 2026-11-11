using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    Task<bool> AddGenre(Genres genre);
    Task<bool> UpdateGenre(Genres genre);
    Task<bool> DeleteGenre(int id);
    Task<Genres> GetGenre(int id);
    Task<List<Genres>> GetGenres();

    Task<int> GetGenresAmount();
    Task<int> GetMinPublishedYearByGenre(int genreId);
    Task<int> GetMaxPublishedYearByGenre(int genreId);
    Task<int> GetAmountByGenre(int genreId);

}
