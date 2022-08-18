namespace Mapster.Playground.DtoWithDifferentNames;

public class ProductAttributeDto
{
    public Guid OtherId { get; set; } = default!;

    public string OtherName { get; set; } = default!;

    public string OtherValue { get; set; } = default!;
}