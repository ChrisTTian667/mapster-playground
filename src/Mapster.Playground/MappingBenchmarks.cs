using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Mapster.Playground.Dto;
using Mapster.Playground.Entity;
using Mapster.Playground.MappingConfiguration;

namespace Mapster.Playground;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MappingBenchmarks
{
    private static readonly IMapper Automapper;
    private static readonly MapsterMapper.IMapper MapsterMapper;

    static MappingBenchmarks()
    {
        Automapper = new Mapper(new MapperConfiguration(configure => configure
            .AddProfile(new AutomapperMappingProfile())));

        MapsterMapper = new MapsterMapper.Mapper(MapsterProfile.GetTypeAdapterConfig());
    }

    public static IReadOnlyList<Product> Data { get; set; } = null!;

    // Simple Mapping => DTO looks exactly the same as the Entity
    [Benchmark]
    public IReadOnlyList<ProductDto> SimpleWithAutomapperProfile() =>
        Automapper.Map<IReadOnlyList<ProductDto>>(Data);

    [Benchmark]
    public IReadOnlyList<ProductDto> SimpleWithMapsterAdaptWithoutConfig() =>
        Data.Adapt<IReadOnlyList<ProductDto>>();

    [Benchmark]
    public IReadOnlyList<ProductDto> SimpleWithMapsterAdaptWithConfig() =>
        MapsterMapper.From(Data).AdaptToType<IReadOnlyList<ProductDto>>();

    // Complex Mapping => DTO property names differ from Entity property names
    [Benchmark]
    public IReadOnlyList<DtoWithDifferentNames.ProductDto> ComplexWithAutomapperProfile() =>
        Automapper.Map<IReadOnlyList<DtoWithDifferentNames.ProductDto>>(Data);

    [Benchmark]
    public IReadOnlyList<DtoWithDifferentNames.ProductDto> ComplexWithMapsterAdaptWithConfig() =>
        MapsterMapper.From(Data).AdaptToType<IReadOnlyList<DtoWithDifferentNames.ProductDto>>();

    // Magic Mapping => DTO contains computed property
    [Benchmark]
    public IReadOnlyList<DtoWithValidation.ProductDto> ValidationWithAutomapperProfile() =>
        Automapper.Map<IReadOnlyList<DtoWithValidation.ProductDto>>(Data, opts =>
            opts.Items.Add("ValidationResults",
                new List<ValidationResult>()));

    // [Benchmark]
    // public IReadOnlyList<DtoWithValidation.ProductDto> ValidationWithMapsterAdaptWithConfig() =>
    //     MapsterMapper.From(Data).AdaptToType<IReadOnlyList<DtoWithValidation.ProductDto>>();
}