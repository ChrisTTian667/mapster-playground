using System.ComponentModel.DataAnnotations;

namespace Mapster.Playground.Entity;

public class Product
{
    public Guid Id { get; set; }

    [MinLength(15)]
    public string Name { get; set; } = default!;

    [MinLength(7)]
    public string Brand { get; set; } = default!;

    [MinLength(10)]
    public string Description { get; set; } = default!;

    public IReadOnlyList<ProductDetails> Details { get; set; } = default!;
}