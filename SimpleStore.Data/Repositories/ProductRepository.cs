namespace SimpleStore.Data.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleStore.Data.Data;
using SimpleStore.Data.Models;

public class ProductRepository(ApplicationDbContext context, IConfiguration configuration) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    public readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
            .OrderBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public int GetTotalProducts()
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = new("SELECT COUNT(*) FROM Products", connection);
        connection.Open();
        return (int) command.ExecuteScalar();
    }
}