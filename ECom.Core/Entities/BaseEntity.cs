namespace ECom.Core.Entities;
public class BaseEntity<T>
{
    public T Id { get; set; }
    public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public bool IsAvaliable { get; set; }
}
