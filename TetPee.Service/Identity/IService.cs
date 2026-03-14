using TetPee.Service.User;

namespace TetPee.Service.Identity;

public interface IService
{
    public Task<Response.IndentityResponse> Login(string email, string password);

}