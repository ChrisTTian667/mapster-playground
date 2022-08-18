namespace Mapster.Playground.Dto;

public class ProductDetailsDto
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public IReadOnlyList<ProductAttributeDto> Attributes { get; set; } = default!;
}