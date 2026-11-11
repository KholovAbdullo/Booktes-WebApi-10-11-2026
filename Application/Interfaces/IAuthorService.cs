
using Application.DTOs.Authors;
using Application.Responses;
namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto);
    Task<ApiResponse<bool>> UpdateAuthor(UpdateAuthorDto authorDto);
    Task<ApiResponse<bool>> DeleteAuthor(int id);
    Task<ApiResponse<AuthorDto>> GetAuthor(int id);
    Task<ApiResponse<List<AuthorDto>>> GetAuthors();
    Task<ApiResponse<AuthorStatisticDto>> GetAuthorStatistic(int authorId);
}
