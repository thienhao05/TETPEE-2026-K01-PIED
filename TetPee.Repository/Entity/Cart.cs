using TetPee.Repository.Abtraction;

namespace TetPee.Repository.Entity;

public class Cart: BaseEntity<Guid>, IAuditableEntity
{
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    // public bool IsDeleted { get; set; } = false; // Soft Delete, Tránh xung đột khóa ngoại (Foreign Key Constraint)
    // public DateTimeOffset CreatedAt { get; set; } // Dòng dữ liệu này được tạo ra khi nào
    // public DateTimeOffset? UpdatedAt { get; set; } // Dòng dữ liệu này được cập nhật lần cuối khi nào
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}