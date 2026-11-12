using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository(Database database):IGenreRepository
{
    private Database data = database;

        public async Task<bool> AddGenre(Genres genre)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="insert into Genres(name) values(@name)";
        var res = await conn.ExecuteAsync(query,new{genre.Name});
        return res > 0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="delete from Genres where id=@id";
        var res = await conn.ExecuteAsync(query,new{id});
        return res > 0;
    }

    public async Task<int> GetAmountByGenre(int genreId)
    {
        using var conn = data.Connection();
        conn.Open();
        var query="select count(*) from Books where id=@genreId";
        var res = await conn.ExecuteScalarAsync<int>(query,new{genreId});
        return res;
    }


    public async Task<Genres> GetGenre(int id)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="select * from Genres where id=@id";
        var genre = await conn.QuerySingleOrDefaultAsync<Genres>(query,new{id});
        return genre!;
    }

    public async Task<List<Genres>> GetGenres()
    {
        using var conn=data.Connection();
        conn.Open();
        var query = await conn.QueryAsync<Genres>("select * from Genres");
        return query.ToList();
    }

    public async Task<int> GetGenresAmount()
    {
        using var conn=data.Connection();
        conn.Open();
        var query="select count(*) from Genres";
        var res = await conn.ExecuteScalarAsync<int>(query);
        return res;
    }

    public async Task<int> GetMaxPublishedYearByGenre(int genreId)
    {
        using var conn=data.Connection();
        conn.Open();
        var query = "select max(publishedyear) from Books where id=@genreId";
        var res = await conn.ExecuteScalarAsync<int>(query,new {genreId});
        return res;
    }

    public async Task<int> GetMinPublishedYearByGenre(int genreId)
    {
        using var conn=data.Connection();
        conn.Open();
        var query = "select min(publishedyear) from Books where id=@genreId";
        var res = await conn.ExecuteScalarAsync<int>(query,new {genreId});
        return res;
    }


    public async Task<bool> UpdateGenre(int id,Genres genre)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="update Genres set name=@name where id=@id";
        var res = await conn.ExecuteAsync(query, new {id,genre.Name});
        return res>0;
    }
}
