namespace SimpleStore.Business.Services;
using SimpleStore.Business.DTOs;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProducts();
    Task<ProductDto> GetProductById(int id);
    Task<ProductDto> CreateProduct(CreateProductDto productDto);
    Task UpdateProduct(UpdateProductDto productDto);
    Task DeleteProduct(int id);
}