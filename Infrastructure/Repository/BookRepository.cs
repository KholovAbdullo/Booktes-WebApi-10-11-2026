using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class BookRepository(Database database):IBookRepository
{
    private Database data = database;

        public async Task<bool> AddBook(Books book)
    {
        using var Connection=data.Connection();
        Connection.Open();
        var query = @"insert into Books(title, publishedyear, totalcopies, author_id, genre_id) values(@Title, @Publishedyear, @Totalcopies, @authorId, @genreId)";
        var res = await Connection.ExecuteAsync(query, new{book.Title,book.Publishedyear,book.Totalcopies,book.authorId,book.genreId});
        return res > 0;
    }

    public async Task<bool> DeleteBook(int id)
    {
        using var Connection=data.Connection();
        Connection.Open();
        var query="delete from Books where id=@id";
        var res = await Connection.ExecuteAsync(query,new{id});
        return res > 0;
    }

    public async Task<Books> GetBook(int id)
    {
       using var Connection=data.Connection();
       Connection.Open();
       var query="select * from Books where id=@id";
       var book = await Connection.QuerySingleOrDefaultAsync<Books>(query,new{id});
       return book!;
    }

    public async Task<List<Books>> GetBooks()
    {
        using var Connection=data.Connection();
        Connection.Open();
        var query = await Connection.QueryAsync<Books>("select * from Books");
        return query.ToList();
    }

    public async Task<bool> UpdateBook(Books book)
    {
        using var Connection=data.Connection();
        Connection.Open();
        var query="update Books set title=@title, publishedyear=@publishedyear,totalcopies=@totalcopies,author_id=@authorId,genre_id=@genreId where id=@id";
        var res = await Connection.ExecuteAsync(query,book);
        return res > 0;
    }
}
