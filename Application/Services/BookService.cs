using System.Net;
using System.Security.Cryptography;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepository bookRepository):IBookService
{
    private IBookRepository books = bookRepository;

    public async Task<ApiResponse<bool>> AddBook(Books book)
    {
        var res = await books.AddBook(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var res = await books.DeleteBook(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<Books>> GetBook(int id)
    {
        var res = await books.GetBook(id);
        return res != null
        ? new ApiResponse<Books>(HttpStatusCode.OK, "GetBook id!", res)
        : new ApiResponse<Books>(HttpStatusCode.NotFound, "Not GetBook id!", res!);
    }

    public async Task<ApiResponse<List<Books>>> GetBooks()
    {
        var res = await books.GetBooks();
        return new ApiResponse<List<Books>>(HttpStatusCode.OK, "ListBooks!",res);
    }

    public async Task<ApiResponse<bool>> UpdateBook(Books book)
    {
        var res = await books.UpdateBook(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!", res);
    }

}
