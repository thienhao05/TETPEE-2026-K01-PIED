using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _dbContext;
    
    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryResponse.GetCategoriesResponse>> GetCategories(string? searchTerm)
    {
        var query = _dbContext.Categories.Where(x => true);
        
        if (searchTerm != null)
        {
            query = query.Where(x => x.Name.Contains(searchTerm));
        }
        query = query.OrderBy(x => x.Name);

        var seletedQuery = query
            .Select(x => new CategoryResponse.GetCategoriesResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        
        var result = await seletedQuery.ToListAsync();
        return  result;
    }

    public async Task<List<CategoryResponse.GetCategoriesResponse>> GetCategoryByParentId(Guid parentId)
    {
        var query = _dbContext.Categories.Where(x => x.ParentId == parentId);
        
        query = query.OrderBy(x => x.Name);

        var selectedQuery = query
            .Select(x => new CategoryResponse.GetCategoriesResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}