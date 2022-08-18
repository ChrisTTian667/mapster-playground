namespace Mapster.Playground.DtoWithValidation;

public class ProductDetailsDto : ValidationDto
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public IReadOnlyList<ProductAttributeDto> Attributes { get; set; } = default!;
}