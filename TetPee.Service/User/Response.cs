namespace TetPee.Service.User;

public class Response
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public string? PhoneNumber {get; set; } = null;
        public string? Address { get; set; } = null;
        public string Role { get; set; } = "User";
        //public string? DateOfBirth { get; set; } = null;
    }
    //tạo mới cho anh category và seller 
    //catefory ko phân trang => 
}