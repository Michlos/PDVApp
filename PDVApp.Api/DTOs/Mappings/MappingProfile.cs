using AutoMapper;

using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Uma Categoria tem vários Produtos
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        CreateMap<CategoryDTO, Category>().ReverseMap();

        //Um Produto tem vários Inventários (movimentação de estoque)
        CreateMap<InventoryLogDTO, InventoryLog>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ReverseMap()
            .ForMember(dest => dest.Product, opt => opt.Ignore());


    }
}
