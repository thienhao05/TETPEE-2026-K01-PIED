using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Category;

namespace TetPee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly ICategoryService _categoryService;

    public CategoryController(AppDbContext dbContext, ICategoryService categoryService)
    {
        _dbContext = dbContext;
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCategories([FromQuery] string? searchTerm)
    {
        var categories = await _categoryService.GetCategories(searchTerm);
        return Ok(categories);
    }

    [HttpGet("{parentId}")]
    public async Task<IActionResult> GetCategoryByParentId(Guid parentId)
    {
        var categories = await _categoryService.GetCategoryByParentId(parentId);
        return Ok(categories);
    }
}