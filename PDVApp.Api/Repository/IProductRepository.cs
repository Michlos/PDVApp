using PDVApp.Api.Models;

namespace PDVApp.Api.Repository;

public interface IProductRepository
{
    Task<Product?> GetById(int id);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(int id);
}
