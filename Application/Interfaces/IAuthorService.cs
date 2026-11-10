using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthor(Authors author);
    Task<ApiResponse<bool>> UpdateAuthor(Authors author);
    Task<ApiResponse<bool>> DeleteAuthor(int id);
    Task<ApiResponse<Authors>> GetAuthor(int id);
    Task<ApiResponse<List<Authors>>> GetAuthors();
}
