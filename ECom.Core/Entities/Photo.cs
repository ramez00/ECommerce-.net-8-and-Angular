
namespace ECom.Core.Entities;
public class Photo : BaseEntity<int>
{
    public string ImageName { get; set; }
    public string Url { get; set; } = string.Empty;
    public string PublicId { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public int ProductId { get; set; }
}
