using System.ComponentModel.DataAnnotations;

namespace Mapster.Playground.Entity;

public class ProductAttribute
{
    public Guid Id { get; set; } = default!;

    [MinLength(5)]
    public string Name { get; set; } = default!;

    [MinLength(30)]
    public string Value { get; set; } = default!;
}