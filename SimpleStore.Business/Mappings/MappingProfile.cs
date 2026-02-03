namespace SimpleStore.Business.Mappings;

using AutoMapper;
using SimpleStore.Business.DTOs;
using SimpleStore.Data.Models;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}