namespace ECom.Core.Entities;
public class Product : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
}
