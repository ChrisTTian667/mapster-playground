using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Mapster.Playground.Dto;
using Mapster.Playground.Entity;

namespace Mapster.Playground.MappingConfiguration;

public class AutomapperMappingProfile : Profile
{
    public AutomapperMappingProfile()
    {
        // DTO looks exactly like the entity
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDetails, ProductDetailsDto>();
        CreateMap<ProductAttribute, ProductAttributeDto>();

        // DTO with different names
        CreateMap<Product, DtoWithDifferentNames.ProductDto>()
            .ForMember(p => p.OtherId, opt => opt.MapFrom(p => p.Id))
            .ForMember(p => p.OtherName, opt => opt.MapFrom(p => p.Name))
            .ForMember(p => p.OtherBrand, opt => opt.MapFrom(p => p.Brand))
            .ForMember(p => p.OtherDescription, opt => opt.MapFrom(p => p.Description))
            .ForMember(p => p.OtherDetails, opt => opt.MapFrom(p => p.Details));

        CreateMap<ProductDetails, DtoWithDifferentNames.ProductDetailsDto>()
            .ForMember(p => p.OtherId, opt => opt.MapFrom(p => p.Id))
            .ForMember(p => p.OtherPrice, opt => opt.MapFrom(p => p.Price))
            .ForMember(p => p.OtherAttributes, opt => opt.MapFrom(p => p.Attributes));

        CreateMap<ProductAttribute, DtoWithDifferentNames.ProductAttributeDto>()
            .ForMember(p => p.OtherId, opt => opt.MapFrom(p => p.Id))
            .ForMember(p => p.OtherName, opt => opt.MapFrom(p => p.Name))
            .ForMember(p => p.OtherValue, opt => opt.MapFrom(p => p.Value));

        // DTO with magic validation
        // This is a simplified version which doesn't require the context at all,
        // but in our real world scenario we would need the context to get the validation messages of the whole tree.
        CreateMap<Product, DtoWithValidation.ProductDto>()
            .BeforeMap((src, _, ctx) =>
            {
                var validationContext = new ValidationContext(src);
                var validationResults = (List<ValidationResult>)ctx.Items["ValidationResults"];

                Validator.TryValidateObject(src, validationContext, validationResults);
            })
            .ForMember(dst => dst.ValidationErrors, opt =>
                opt.MapFrom((_, _, _, ctx) =>
                    ((List<ValidationResult>)ctx.Items["ValidationResults"]).Select(vr => vr.ErrorMessage)));

        CreateMap<ProductDetails, DtoWithValidation.ProductDetailsDto>()
            .BeforeMap((src, _, ctx) =>
            {
                var validationContext = new ValidationContext(src);
                var validationResults = (List<ValidationResult>)ctx.Items["ValidationResults"];

                Validator.TryValidateObject(src, validationContext, validationResults);
            })
            .ForMember(dst => dst.ValidationErrors, opt =>
                opt.MapFrom((_, _, _, ctx) =>
                    ((List<ValidationResult>)ctx.Items["ValidationResults"]).Select(vr => vr.ErrorMessage)));

        CreateMap<ProductAttribute, DtoWithValidation.ProductAttributeDto>()
            .BeforeMap((src, _, ctx) =>
            {
                var validationContext = new ValidationContext(src);
                var validationResults = (List<ValidationResult>)ctx.Items["ValidationResults"];

                Validator.TryValidateObject(src, validationContext, validationResults);
            })
            .ForMember(dst => dst.ValidationErrors, opt =>
                opt.MapFrom((_, _, _, ctx) =>
                    ((List<ValidationResult>)ctx.Items["ValidationResults"]).Select(vr => vr.ErrorMessage)));
    }
}