namespace TetPee.Service.Category;

public class CategoryResponse
{
    public class GetCategoriesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null;
    }
}