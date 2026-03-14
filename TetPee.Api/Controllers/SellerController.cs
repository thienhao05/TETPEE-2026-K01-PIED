using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Seller;

namespace TetPee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SellerController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly ISellerService _sellerService;

    public SellerController(AppDbContext dbContext, ISellerService sellerService)
    {
        _dbContext = dbContext;
        _sellerService = sellerService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetSellers([FromQuery] string? searchTerm, int pageSize = 10, int pageIndex = 1)
    {
        var sellers = await _sellerService.GetSellers(searchTerm, pageSize, pageIndex);
        return Ok(sellers);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSellerById([FromRoute] Guid id)
    {
        var seller = await _sellerService.GetSellerById(id);
        return Ok(seller);
    }
}