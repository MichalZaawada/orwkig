using MyList.Api.Commands;
using MyList.Api.DAL.Repositories;
using MyList.Api.DTO;
using MyList.Api.Entities;

namespace MyList.Api.Services;

public class ListService : IListService
{
    private readonly IProductRepository _productRepository;

    public ListService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductDTO> AddProductAsync(AddProductCommand command)
    {
        var description = command.Description;
        var quantity = command.Quantity;

        var product = new Product(description, quantity);
        
        await _productRepository.AddAsync(product);

        return new ProductDTO
        {
            Id = product.Id,
            Description = product.Description,
            Quantity = product.Quantity
        };
    }

    public async Task<bool> DeleteProductAsync(DeleteProductCommand command)
    {
        var productId = command.Id;
        var product = await _productRepository.GetByIdAsync(productId);

        if (product == null) 
        {
            return false; 
        }

        await _productRepository.DeleteAsync(product);
        return true;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(x => new ProductDTO
        {
            Id = x.Id,
            Description = x.Description,
            Quantity = x.Quantity
        });
    }
}