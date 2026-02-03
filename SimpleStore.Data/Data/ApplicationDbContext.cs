namespace SimpleStore.Data.Data;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Data.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<Product> Products {get; set;}
}
