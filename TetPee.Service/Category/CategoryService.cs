using TetPee.Repository;

namespace TetPee.Service.Category;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _dbContext;
    
    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<CategoryResponse.GetCategoriesResponse>> GetCategories(string? searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryResponse.GetCategoriesResponse>> GetCategoryByParentId(Guid parentId)
    {
        throw new NotImplementedException();
    }
}