using Microsoft.EntityFrameworkCore;
using MyList.Api.Entities;

namespace MyList.Api.DAL.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly MyListDbContext _myListDbContext;

    public ProductRepository(MyListDbContext myListDbContext)
    {
        _myListDbContext = myListDbContext;
    }
    public async Task AddAsync(Product product)
    {
        await _myListDbContext.AddAsync(product);
        await _myListDbContext.SaveChangesAsync();
    }
    

    public async Task DeleteAsync(Product product)
    {
        _myListDbContext.Remove(product);
        await _myListDbContext.SaveChangesAsync();

    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
       await _myListDbContext.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _myListDbContext.Products.FirstOrDefaultAsync<Product>(x => x.Id == id);
}
