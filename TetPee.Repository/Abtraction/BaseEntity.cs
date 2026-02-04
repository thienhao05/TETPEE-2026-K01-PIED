namespace TetPee.Repository.Abtraction;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } //trong database tự tạo cho mình luôn
    
    public bool IsDeleted { get; set; }  //Soft Delete. Tránh xung đột khóa ngoại (Foreign Key Constraint)
}