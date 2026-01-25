using TetPee.Repository.Abtraction;

namespace TetPee.Repository.Entity;

public class Seller: BaseEntity<Guid>, IAuditableEntity
{
    public required string TaxCode { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyAddress { get; set; }
    
    //tạo khóa ngoại
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    //1 seller có 1 danh sách sản phẩm
    public ICollection<Product> Products { get; set; } = new List<Product>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}