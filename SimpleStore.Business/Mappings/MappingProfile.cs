namespace SimpleStore.Business.Mappings;

using AutoMapper;
using SimpleStore.Business.DTOs;
using SimpleStore.Data.Models;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, ProductDto>().ReverseMap();
    }
}