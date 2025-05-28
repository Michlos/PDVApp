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

        CreateMap<CashRegisterDTO, CashRegister>().ReverseMap();

        CreateMap<SaleDTO, Sale>()
            .ForMember(dest => dest.CashRegister, opt => opt.MapFrom(src => src.CashRegister))
            .ReverseMap()
            .ForMember(dest => dest.CashRegister, opt => opt.Ignore());

        CreateMap<SaleItemDTO, SaleItem>()
            .ForMember(dest => dest.Sale, opt => opt.MapFrom(src => src.Sale))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ReverseMap()
            .ForMember(dest => dest.Sale, opt => opt.Ignore())
            .ForMember(dest => dest.Product, opt => opt.Ignore());

        CreateMap<PaymentMethodDTO, PaymentMethod>()
            .ReverseMap();





    }
}
