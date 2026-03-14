namespace TetPee.Service.Category;

public interface ICategoryService
{
    public Task<List<CategoryResponse.GetCategoriesResponse>> GetCategories(string? searchTerm);
    public Task<List<CategoryResponse.GetCategoriesResponse>> GetCategoryByParentId(Guid parentId);
}