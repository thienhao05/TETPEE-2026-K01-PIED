using TetPee.Repository.Abtraction;

namespace TetPee.Repository.Entity;

public class ProductStorage : BaseEntity<Guid>, IAuditableEntity
{
    //làm cái storage nha
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}