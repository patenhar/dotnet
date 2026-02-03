using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Business.DTOs;

public class CreateProductDto
{    
    [Required(ErrorMessage = "Title is required")]
    public required string Title {get; set;}
    
    [Required(ErrorMessage = "Description is required")]
    public required string Description {get; set;}
        
    [Required(ErrorMessage = "Stock is required")]
    public required int Stock {get; set;}
}

public class UpdateProductDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id {get; set;} = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    public required string Title {get; set;}
    
    [Required(ErrorMessage = "Description is required")]
    public required string Description {get; set;}
        
    [Required(ErrorMessage = "Stock is required")]
    public required int Stock {get; set;}
}

public class ProductDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id {get; set;} = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    public required string Title {get; set;}
    
    [Required(ErrorMessage = "Description is required")]
    public required string Description {get; set;}
        
    [Required(ErrorMessage = "Stock is required")]
    public required int Stock {get; set;}
}