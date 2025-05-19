using PDVApp.Api.DTOs;

namespace PDVApp.Api.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task AddProduct(ProductDTO productDto);
    Task UpdateProduct(ProductDTO productDto);
    Task RemoveProduct(int id);
}
