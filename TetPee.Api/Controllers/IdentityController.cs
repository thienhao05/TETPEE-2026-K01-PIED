using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Identity;

namespace TetPee.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
     private readonly IService _indentityService;

     public IdentityController(IService indentityService)
     {
          _indentityService = indentityService;
     }
     
     [HttpGet("")]
     public async Task<IActionResult> Login(string  email, string password)
     {
         var result = await _indentityService.Login(email, password);
         return Ok(result);
     }
}