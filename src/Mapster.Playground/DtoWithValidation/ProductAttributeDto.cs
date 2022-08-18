namespace Mapster.Playground.DtoWithValidation;

public class ProductAttributeDto : ValidationDto
{
    public Guid Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Value { get; set; } = default!;
}