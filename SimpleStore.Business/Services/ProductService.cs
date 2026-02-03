using AutoMapper;
using SimpleStore.Business.DTOs;
using SimpleStore.Data.Models;
using SimpleStore.Data.Repositories;

namespace SimpleStore.Business.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper): IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public int GetTotalProducts()
    {
        return _productRepository.GetTotalProducts();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductById(Guid id)
    {
        return _mapper.Map<ProductDto>(await _productRepository.GetById(id));
    }

    public async Task<ProductDto> CreateProduct(CreateProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        return _mapper.Map<ProductDto>(await _productRepository.Add(product));
    }

    public async Task UpdateProduct(UpdateProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _productRepository.Update(product);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _productRepository.Delete(id);
    }
}