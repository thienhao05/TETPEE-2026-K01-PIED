using TetPee.Repository.Abtraction;

namespace TetPee.Repository.Entity;

public class OrderDetail: BaseEntity<Guid>, IAuditableEntity
{
    //1 OrderDetail có nhiều Order
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    
    //1 OrderDetail có nhiều Product
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}