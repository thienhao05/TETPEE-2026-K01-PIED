using TetPee.Repository.Abtraction;

namespace TetPee.Repository.Entity;

public class Product: BaseEntity<Guid>, IAuditableEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string UrlImage { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    //1 sản phẩm thuộc về 1 seller
    public Guid SellerId { get; set; }
    public Seller Seller { get; set; }
    
    //thằng này chứa khóa ngoại, để bên nào cũng đc
    public Inventory Inventory { get; set; } //lúc này ORM này sẽ hiểu

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public ICollection<ProductStorage> ProductStorages { get; set; } = new List<ProductStorage>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}