namespace TetPee.Service.User;

public class Request
{
    //thằng nào xài body thì mình mới cho thằng này vào, kiếm thằng post
    public class CreateUserRequest
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
    }
    
    public class UpdateUserRequest : CreateUserRequest
    {
        //sửa thì mình phải có id để kiếm trong database
        public Guid Id { get; set; }
    }
}