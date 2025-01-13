namespace Globomantics.Domain.Models;

public class Cart
{
    public Guid CartId { get; init; }  = Guid.NewGuid();

    public bool Finalized { get; set; }

    public string? CustomerEmail { get; set; }

    public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;

    public virtual ICollection<LineItem> LineItems { get; set; }  = new List<LineItem>();
}