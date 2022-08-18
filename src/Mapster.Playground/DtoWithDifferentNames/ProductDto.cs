namespace Mapster.Playground.DtoWithDifferentNames;

public class ProductDto
{
    public Guid OtherId { get; set; }

    public string OtherName { get; set; } = default!;

    public string OtherBrand { get; set; } = default!;

    public string OtherDescription { get; set; } = default!;

    public IReadOnlyList<ProductDetailsDto> OtherDetails { get; set; } = default!;
}