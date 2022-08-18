using Mapster.Playground.Dto;
using Mapster.Playground.Entity;

namespace Mapster.Playground.MappingConfiguration;

public static class MapsterProfile
{
    public static TypeAdapterConfig GetTypeAdapterConfig()
    {
        var config = new TypeAdapterConfig();

        // DTO looks exactly like Entity
        config.NewConfig<Product, ProductDto>();
        config.NewConfig<ProductDetails, ProductDetailsDto>();
        config.NewConfig<ProductAttribute, ProductAttributeDto>();

        // DTO has other property names
        config.NewConfig<Product, DtoWithDifferentNames.ProductDto>()
            .Map(p => p.OtherId, p => p.Id)
            .Map(p => p.OtherName, p => p.Name)
            .Map(p => p.OtherBrand, p => p.Brand)
            .Map(p => p.OtherDescription, p => p.Description)
            .Map(p => p.OtherDetails, p => p.Details);

        config.NewConfig<ProductDetails, DtoWithDifferentNames.ProductDetailsDto>()
            .Map(p => p.OtherId, p => p.Id)
            .Map(p => p.OtherPrice, p => p.Price)
            .Map(p => p.OtherAttributes, p => p.Attributes);

        config.NewConfig<ProductAttribute, DtoWithDifferentNames.ProductAttributeDto>()
            .Map(p => p.OtherId, p => p.Id)
            .Map(p => p.OtherName, p => p.Name)
            .Map(p => p.OtherValue, p => p.Value);

        return config;
    }
}