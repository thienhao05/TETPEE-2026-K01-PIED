namespace TetPee.Service.Category;

public class CategoryRequest
{
    public class CreateCategoryRequest
    {
        public required string Name { get; set; }
        public Guid? ParentId { get; set; } 
    }

    public class UpdateCategoryRequest : CreateCategoryRequest
    {
        //sửa thì mình phải có id để kiếm trong database
        public Guid Id { get; set; }
    }
}