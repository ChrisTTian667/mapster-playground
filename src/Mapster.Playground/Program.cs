using BenchmarkDotNet.Running;
using Bogus;
using Mapster.Playground;
using Mapster.Playground.Entity;

MappingBenchmarks.Data = CreateTestData(10);
BenchmarkRunner.Run<MappingBenchmarks>();

static IReadOnlyList<Product> CreateTestData(int count)
{
    var attributeFaker = new Faker<ProductAttribute>()
        .RuleFor(p => p.Id, _ => Guid.NewGuid())
        .RuleFor(p => p.Name, f => f.Hacker.Noun())
        .RuleFor(p => p.Value, f => f.Hacker.Phrase());

    var detailFaker = new Faker<ProductDetails>()
        .RuleFor(p => p.Id, _ => Guid.NewGuid())
        .RuleFor(p => p.Price, f => f.Random.Decimal(0, 100))
        .RuleFor(p => p.Attributes, _ => attributeFaker.Generate(20));

    var productFaker = new Faker<Product>()
        .RuleFor(p => p.Id, _ => Guid.NewGuid())
        .RuleFor(p => p.Name, f => f.Random.Word())
        .RuleFor(p => p.Brand, f => f.Random.Word())
        .RuleFor(p => p.Description, f => f.Random.Words(7))
        .RuleFor(p => p.Details, _ => detailFaker.Generate(5));

    return productFaker.Generate(count);
}