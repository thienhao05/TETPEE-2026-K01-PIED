namespace TetPee.Repository.Abtraction;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; } // Dòng dữ liệu này đc tạo ra khi nào
    public DateTimeOffset? UpdatedAt { get; set; } // Dòng dữ liệu này được cập nhật lần cuối khi nào
}