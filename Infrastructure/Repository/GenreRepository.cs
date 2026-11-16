using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenreRepository(Database database):IGenreRepository
{
    private Database data = database;

    public async Task<bool> AddGenre(Genres genre)
    {
        data.Genres.Add(genre);
        var res = await data.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        var res = await data.Genres.FirstOrDefaultAsync(x=>x.Id==id);
        if (res != null)
        {
            data.Genres.Remove(res);
        }

        var re = await data.SaveChangesAsync();
        return re>0;
    }

    public async Task<int> GetAmountByGenre(int genreId)
    {
        return await data.Books.CountAsync(x=>x.genreId==genreId);
    }

    public async Task<Genres> GetGenre(int id)
    {
        var res = await data.Genres.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null)
        {
            return null!;
        }

        return res;
    }

    public async Task<List<Genres>> GetGenres()
    {
        return await data.Genres.ToListAsync();
    }

    public async Task<int> GetGenresAmount()
    {
        return await data.Genres.CountAsync();
    }

    public async Task<int> GetMaxPublishedYearByGenre(int genreId)
    {
        return await data.Books.Where(x=>x.genreId==genreId).MaxAsync(x=>x.Publishedyear);
    }

    public async Task<int> GetMinPublishedYearByGenre(int genreId)
    {
        return await data.Books.Where(x=>x.genreId==genreId).MinAsync(x=>x.Publishedyear);
    }

    public async Task<bool> UpdateGenre(int id, Genres genre)
    {
        var gen = await data.Genres.FirstOrDefaultAsync(x=>x.Id==id);
        if (gen != null)
        {
            gen.Name=genre.Name;
        }

        var res = await data.SaveChangesAsync();
        return res>0;
    }

}
