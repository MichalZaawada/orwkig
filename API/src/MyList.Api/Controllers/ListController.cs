using Microsoft.AspNetCore.Mvc;
using MyList.Api.Commands;
using MyList.Api.DTO;
using MyList.Api.Services;
using System.ComponentModel.DataAnnotations;

namespace MyList.Api.Controllers;

[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly IListService _listService;

    public ListController(IListService listService)
    {
        _listService = listService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAsync() =>
        Ok(await _listService.GetProductsAsync());

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> PutAsync([Required] AddProductCommand command)
    {
        var product = await _listService.AddProductAsync(command);
        return Ok(product);
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(DeleteProductCommand command)
    {
        var isSuccess = await _listService.DeleteProductAsync(command);
        return isSuccess ? NoContent() : NotFound();
    }
}
