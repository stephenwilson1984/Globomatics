namespace Globomantics.Domain.Models;

public class Order
{
    public Guid OrderId { get; init; } = Guid.NewGuid();

    public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();

    public virtual Customer? Customer { get; set; }

    public required Guid CustomerId { get; set; }

    // SQLite doesn't support DateTimeOffset, we have to ensure dates are always UTC!
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public decimal OrderTotal => LineItems?.Sum(item => item.Product?.Price * item.Quantity) ?? 0;
}