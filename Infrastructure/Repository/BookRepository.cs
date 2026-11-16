using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BookRepository(Database database):IBookRepository
{
    private Database data = database;

    public async Task<bool> AddBook(Books book)
    {
        data.Books.Add(book);
        var res = await data.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await data.Books.FirstOrDefaultAsync(x=>x.Id==id);
        if (book !=null)
        {
            data.Books.Remove(book);
        }

        var res = await data.SaveChangesAsync();
        return res>0;
    }

    public async Task<int> GetAmountByPublishedYear(int year)
    {
        return await data.Books.CountAsync(x=>x.Publishedyear==year);
    }

    public async Task<Books> GetBook(int id)
    {
        var res = await data.Books.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null)
        {
            return null!;
        }
        return res;
    }

    public async Task<int> GetBookAmount()
    {
        return await data.Books.CountAsync();
    }

    public async Task<List<Books>> GetBooks()
    {
        return await data.Books.ToListAsync();
    }

    public async Task<bool> UpdateBook(int id, Books book)
    {
        var bo = await data.Books.FirstOrDefaultAsync(x=>x.Id==id);
        if (bo != null)
        {
            bo.Title=book.Title;
            bo.Publishedyear=book.Publishedyear;
            bo.Totalcopies=book.Totalcopies;
            bo.authorId=book.authorId;
            bo.genreId=book.genreId;
        }

        var res = await data.SaveChangesAsync();
        return res>0;
    }

}
