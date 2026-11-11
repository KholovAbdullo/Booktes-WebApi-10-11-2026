using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository):IAuthorService
{
    private IAuthorRepository authors = authorRepository;

    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        var author = new Authors()
        {
            Fullname=authorDto.Fullname,
            Country=authorDto.Country,
            Birthyear=authorDto.Birthyear
        };

        var res = await authors.AddAuthor(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var res = await authors.DeleteAuthor(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!", res);
    }

    public async Task<ApiResponse<AuthorDto>> GetAuthor(int id)
    {
        var res = await authors.GetAuthor(id);

        if (res == null)
        {
            return new ApiResponse<AuthorDto>(HttpStatusCode.NotFound, "Author not faund!", null!);
        }
        var author = new AuthorDto()
        {
            Id=res.Id,
            Fullname=res.Fullname,
            Country=res.Country,
            Birthyear=res.Birthyear
        };

        return new ApiResponse<AuthorDto>(HttpStatusCode.OK, "Author!", author);
    }

    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        var res = await authors.GetAuthors();
        var author=res.Select(a=>new AuthorDto
        {
            Id=a.Id,
            Fullname=a.Fullname,
            Country=a.Country,
            Birthyear=a.Birthyear
        }).ToList();

        return new ApiResponse<List<AuthorDto>>(HttpStatusCode.OK, "List Authors!", author);
    }

    public async Task<ApiResponse<AuthorStatisticDto>> GetAuthorStatistic(int authorId)
    {
        var res = new AuthorStatisticDto();
        res.AuthorsAmount=await authors.GetAuthorsAmount();
        res.MaxPublishedYear=await authors.GetMaxPublishedYearByAuthor(authorId);
        res.MinPublishedYear=await authors.GetMinPublishedYearByAuthor(authorId);
        return new ApiResponse<AuthorStatisticDto>(HttpStatusCode.OK, "Authro statistic!", res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(UpdateAuthorDto authorDto)
    {
        var author = new Authors()
        {
            Id=authorDto.Id,
            Fullname=authorDto.Fullname,
            Country=authorDto.Country,
            Birthyear=authorDto.Birthyear
        };

        var res = await authors.UpdateAuthor(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }
}
