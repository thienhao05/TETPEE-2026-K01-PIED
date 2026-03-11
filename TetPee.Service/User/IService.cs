namespace TetPee.Service.User;

public interface IService
{
    public Task<Base.Response.PageResult<Response.GetUserResponse>> GetUsers(
        string? searchTerm,
        int pageSize,
        int pageIndex);
    
    public Task<Response.GetUserResponse?> GetUserById(Guid id);
}