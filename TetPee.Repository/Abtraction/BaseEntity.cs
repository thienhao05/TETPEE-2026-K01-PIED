namespace TetPee.Repository.Abtraction;

public abstract class BaseEntity<TKey>
{
    public required TKey Id { get; set; }
    
    public bool IsDeleted { get; set; }
}