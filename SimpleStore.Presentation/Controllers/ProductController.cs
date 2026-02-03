using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Business.DTOs;
using SimpleStore.Business.Services;
using SimpleStore.Presentation.Filters;

namespace SimpleStore.Presentation.Controllers;

// [ServiceFilter(typeof(ExceptionFilter))]
public class ProductController(IProductService productService, IMapper mapper) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper =  mapper;

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
            return View(productDto);
        await _productService.CreateProduct(productDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound();
        return View(_mapper.Map<UpdateProductDto>(product));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateProductDto productDto)
    {
        if (!ModelState.IsValid)
            return View(productDto);
        await _productService.UpdateProduct(productDto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }


}