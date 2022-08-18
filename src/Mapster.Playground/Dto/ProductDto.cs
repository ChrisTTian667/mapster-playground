namespace Mapster.Playground.Dto;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Brand { get; set; } = default!;

    public string Description { get; set; } = default!;

    public IReadOnlyList<ProductDetailsDto> Details { get; set; } = default!;
}