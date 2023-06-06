using MyList.Api.Commands;
using MyList.Api.DTO;

namespace MyList.Api.Services;

public interface IListService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<bool> DeleteProductAsync(DeleteProductCommand command);
    Task<ProductDTO> AddProductAsync(AddProductCommand command);
}

