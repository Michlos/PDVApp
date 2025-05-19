using AutoMapper;

using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}
