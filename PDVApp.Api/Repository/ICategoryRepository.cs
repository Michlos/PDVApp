using PDVApp.Api.Models;

namespace PDVApp.Api.Repository;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}
