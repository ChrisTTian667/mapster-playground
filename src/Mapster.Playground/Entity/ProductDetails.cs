namespace Mapster.Playground.Entity;

public class ProductDetails
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public IReadOnlyList<ProductAttribute> Attributes { get; set; } = default!;
}