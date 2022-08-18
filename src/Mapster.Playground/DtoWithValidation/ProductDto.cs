namespace Mapster.Playground.DtoWithValidation;

public class ProductDto : ValidationDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Brand { get; set; } = default!;

    public string Description { get; set; } = default!;

    public IReadOnlyList<ProductDetailsDto> Details { get; set; } = default!;
}