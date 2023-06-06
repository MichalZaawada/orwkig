using MyList.Api.Entities;

namespace MyList.Api.DAL.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task DeleteAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
}
