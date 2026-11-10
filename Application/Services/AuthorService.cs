using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository):IAuthorService
{
    private IAuthorRepository authors = authorRepository;

    public async Task<ApiResponse<bool>> AddAuthor(Authors author)
    {
        var res = await authors.AddAuthor(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var res = await authors.DeleteAuthor(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!",res);
    }

    public async Task<ApiResponse<Authors>> GetAuthor(int id)
    {
        var res = await authors.GetAuthor(id);
        return res != null
        ? new ApiResponse<Authors>(HttpStatusCode.OK, "Author id!", res)
        : new ApiResponse<Authors>(HttpStatusCode.NotFound, "Not Author id",res!);
    }

    public async Task<ApiResponse<List<Authors>>> GetAuthors()
    {
        var res = await authors.GetAuthors();
        return new ApiResponse<List<Authors>>(HttpStatusCode.OK, "List Auhtor!",res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(Authors author)
    {
        var res = await authors.UpdateAuthor(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!",res);
    }

}
