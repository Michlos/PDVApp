using AutoMapper;

using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.Ignore());
        CreateMap<CategoryDTO, Category>().ReverseMap();
        CreateMap<InventoryLogDTO, InventoryLog>().ReverseMap();


    }
}
