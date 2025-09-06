namespace ECom.Core.Entities;
public class Category : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Product> products { get; set; } = new HashSet<Product>();
}
