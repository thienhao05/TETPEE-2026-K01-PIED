using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Repository.Entity;
using TetPee.Service.User;

namespace TetPee.Api.Controllers;

//khai báo các API có trong hệ thống
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    //cái này nâng cao lúc sau sẽ giải thích
    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // HTTP Method: GET, POST, DELETE, PUT, PATCH
    // PARAM: Query string, Path Param, Body Param


    //Query String: http://localhost:5000/User?name=abc&age=20
    // name và age là query string
    // Query string nằm sau dấu hỏi ?

    //Path (Route) Param: http://localhost:5000/User/123
    //123 là path param hoặc route param
    //Path param nằm trong đường dẫn

    // GET là ko có body
    // POST, PUT, PATCH có body

    // Tại sao phải dùng body: Tránh để lộ những thông tin ko mong muốn

    // Ví dụ: Username, Pass
    // không thể http://localhost:5000/login?username=abc&password=123 => lộ hết

    // Chuẩn REST FULL API
    // get all users:       GET http://localhost:5000/User
    // create user:         POST http://localhost:5000/User
    // get user by id:      GET http://localhost:5000/User/{id}
    // update user by id:   PUT http://localhost:5000/User/{id}
    // delete user by id:   DELETE http://localhost:5000/User/{id}

    // Tư duy ko chuẩn, mình phải sử dụng restfull API
    //update user by id: http://localhost:5000/User/{id}/update

    [HttpGet("")]
    public IActionResult GetUsers([FromQuery] string? searchTerm)
    {
        var users = _dbContext.Users.ToList();
        throw new Exception("Get Users Errors");
        return Ok(users);
        // return Ok("Get all users")
    }


    //body là mình phải truyền vào 1 object


    [HttpGet("{id}")]
    public IActionResult GetUserById([FromRoute] Guid id) //biến này thuộc về biến param
    {
        // var users = _dbContext.Users.ToList();
        // return Ok(users);
        return Ok(id);
    }

    // mặc dù mình ko để FromBody nhưng mà nó vẫn hiểu
    // Tại vì: nó là 1 cái object, class mà object với class thì nó có thực thể so sánh tương đương 
    // với json mà json thì nó chỉ có thể tìm thấy trong body
    [HttpPut("{id}")]
    public IActionResult UpdateUserById(Guid id, [FromBody] Request.UpdateUserRequest request)
    {
        // var users = _dbContext.Users.ToList();
        // return Ok(users);
        return Ok("Get all users");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(Guid id)
    {
        // var users = _dbContext.Users.ToList();
        // return Ok(users);
        return Ok("Get all users");
    }

    [HttpPost("")]
    public IActionResult CreateUsers([FromBody] Request.CreateUserRequest request)
    {
        var user = new User()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            HashedPassword = request.Password, //chưa hash, chỉ demo
        };

        _dbContext.Users.Add(user); //tui muốn tạo câu lệnh add thôi

        _dbContext.SaveChanges(); //mang câu lệnh này xuống database

        //in cái request ra
        // Console.WriteLine(request); //test debug
        return Ok("Create user successfully");
    }
}