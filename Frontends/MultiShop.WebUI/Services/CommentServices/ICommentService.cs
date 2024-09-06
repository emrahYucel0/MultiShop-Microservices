using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;

namespace MultiShop.WebUI.Services.CommentServices;

public interface ICommentService
{
    Task<List<ResultUserCommentDto>> GetAllCommentAsync();
    Task<List<ResultUserCommentDto>> CommentListByProductId(string id);
    Task CreateCommentAsync(CreateUserCommentDto createCommentDto);
    Task UpdateCommentAsync(UpdateUserCommentDto updateCommentDto);
    Task DeleteCommentAsync(string id);
    Task<UpdateUserCommentDto> GetByIdCommentAsync(string id);
    Task<int> GetTotalCommentCount();
    Task<int> GetActiveCommentCount();
    Task<int> GetPAssiveCommentCount();
}