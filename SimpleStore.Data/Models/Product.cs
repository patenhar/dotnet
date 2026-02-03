using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Data.Models;

public class Product
{
    public Guid Id {get; set;} = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    public required string Title {get; set;}
    
    [Required(ErrorMessage = "Description is required")]
    public required string Description {get; set;}
        
    [Required(ErrorMessage = "Stock is required")]
    public required int Stock {get; set;}
}