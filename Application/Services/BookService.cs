using System.Net;
using Application.DTOs.Books;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepository bookRepository):IBookService
{
    private IBookRepository books = bookRepository;

    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        var book = new Books()
        {
            Title=bookDto.Title,
            Publishedyear=bookDto.Publishedyear,
            Totalcopies=bookDto.Totalcopies,
            authorId=bookDto.authorId,
            genreId=bookDto.genreId
        };

        var res = await books.AddBook(book);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var res = await books.DeleteBook(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!", res);
    }

    public async Task<ApiResponse<BookDto>> GetBook(int id)
    {
        var book = await books.GetBook(id);

        if (book == null)
        {
            return new ApiResponse<BookDto>(HttpStatusCode.NotFound, "Book not faund!", null!);
        }
        var res = new BookDto()
        {
            Id=book.Id,
            Title=book.Title,
            Publishedyear=book.Publishedyear,
            Totalcopies=book.Totalcopies,
            authorId=book.authorId,
            genreId=book.genreId
        };
        return new ApiResponse<BookDto>(HttpStatusCode.OK, "Book!", res);
    }

    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        var res = await books.GetBooks();
        var book = res.Select(b=>new BookDto
        {
            Id=b.Id,
            Title=b.Title,
            Publishedyear=b.Publishedyear,
            Totalcopies=b.Totalcopies,
            authorId=b.authorId,
            genreId=b.genreId
        }).ToList();

        return new ApiResponse<List<BookDto>>(HttpStatusCode.OK, "List Books!", book);
    }

    public async Task<ApiResponse<BookStatisticDto>> GetBookStatistic(int year)
    {
        var res = new BookStatisticDto();
        res.AmountBooks= await books.GetBookAmount();
        res.BooksByPublishedYear=await books.GetAmountByPublishedYear(year);
        return new ApiResponse<BookStatisticDto>(HttpStatusCode.OK, "Book Statistic!", res);
    }

    public async Task<ApiResponse<bool>> UpdateBook(UpdateBookDto bookDto)
    {
        var book = new Books()
        {
            Id=bookDto.Id,
            Title=bookDto.Title,
            Publishedyear=bookDto.Publishedyear,
            Totalcopies=bookDto.Totalcopies,
            authorId=bookDto.authorId,
            genreId=bookDto.genreId
        };
        var res = await books.UpdateBook(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);    
    }
}
