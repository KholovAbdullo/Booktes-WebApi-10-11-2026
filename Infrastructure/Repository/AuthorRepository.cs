using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AuthorRepository(Database database):IAuthorRepository
{
    private Database data = database;

    public async Task<bool> AddAuthor(Authors author)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="insert into Author(fullname,country,birthyear) values(@fullname,@country,@birthyear)";
        var res = await conn.ExecuteAsync(query,new{author.Fullname,author.Country,author.Birthyear});
        return res > 0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="delete from Author where id=@id";
        var res = await conn.ExecuteAsync(query,new{id});
        return res > 0;
    }

    public async Task<Authors> GetAuthor(int id)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="select * from Author where id=@id";
        var author= await conn.QuerySingleOrDefaultAsync<Authors>(query,new{id});
        return author!;
    }

    public async Task<List<Authors>> GetAuthors()
    {
        using var conn=data.Connection();
        conn.Open();
        var query= await conn.QueryAsync<Authors>("select * from Author");
        return query.ToList();
    }

    public async Task<bool> UpdateAuthor(Authors author)
    {
        using var conn=data.Connection();
        conn.Open();
        var query="update Author set fullname=@fullname,country=@country,birthyear=@birthyear where id=@id";
        var res = await conn.ExecuteAsync(query,author);
        return res > 0;
    }
}
