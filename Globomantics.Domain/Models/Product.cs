namespace Globomantics.Domain.Models;

public class Product
{
    public Guid ProductId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required decimal Price { get; set; }
}