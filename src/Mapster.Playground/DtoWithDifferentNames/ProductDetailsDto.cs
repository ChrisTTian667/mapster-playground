namespace Mapster.Playground.DtoWithDifferentNames;

public class ProductDetailsDto
{
    public Guid OtherId { get; set; }

    public decimal OtherPrice { get; set; }

    public IReadOnlyList<ProductAttributeDto> OtherAttributes { get; set; } = default!;
}