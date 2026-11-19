using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AuthorRepository(Database database):IAuthorRepository
{
    private Database data = database;

    public async Task<bool> AddAuthor(Authors author)
    {
        data.Authors.Add(author);
        var res = await data.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        var author = await data.Authors.FirstOrDefaultAsync(x=>x.Id==id);
        if (author != null)
        {
            data.Authors.Remove(author);
        }
        var res = await data.SaveChangesAsync();
        return res>0;
    }

    public async Task<Authors> GetAuthor(int id)
    {
        var res = await data.Authors.Include(x=>x.Books).FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null)
        {
            return null!;
        }
        return res;
    }

    public async Task<List<Authors>> GetAuthors()
    {
        return await data.Authors.Include(x=>x.Books).ToListAsync();
    }

    public async Task<int> GetAuthorsAmount()
    {
        return await data.Authors.CountAsync();
    }

    public async Task<int> GetMaxPublishedYearByAuthor(int authorId)
    {
        return await data.Books.Where(x=>x.AuthorId==authorId).MaxAsync(x=>x.Publishedyear);
    }

    public async Task<int> GetMinPublishedYearByAuthor(int authorId)
    {
        return await data.Books.Where(x=>x.AuthorId==authorId).MinAsync(x=>x.Publishedyear);
    }

    public async Task<bool> UpdateAuthor(int id, Authors author)
    {
        var aut = await data.Authors.FirstOrDefaultAsync(x=>x.Id==id);
        if (aut != null)
        {
            aut.Fullname=author.Fullname;
            aut.Country=author.Country;
            aut.Birthyear=author.Birthyear;
        }

        var res = await data.SaveChangesAsync();
        return res>0;
    }

}
