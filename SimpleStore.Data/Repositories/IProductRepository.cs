using SimpleStore.Data.Models;

namespace SimpleStore.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> GetById(Guid id);
    Task<Product> Add(Product product);
    Task Update(Product product);
    Task Delete(Guid id);
    int GetTotalProducts();
}