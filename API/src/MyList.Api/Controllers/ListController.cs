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
    private readonly ILogger<ListController> _logger;

    public ListController(IListService listService, ILogger<ListController> logger)
    {
        _listService = listService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAsync() =>
        Ok(await _listService.GetProductsAsync());

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> PutAsync([Required] AddProductCommand command)
    {
        _logger.LogInformation("Start adding...");
        if (command.Description == null || command.Quantity == null) { return BadRequest("Problem with parameters"); }
        var product = await _listService.AddProductAsync(command);
        _logger.LogInformation("End adding...");
        return Ok(product);
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(DeleteProductCommand command)
    {
        _logger.LogInformation("Start deleting...");
        var isSuccess = await _listService.DeleteProductAsync(command);
        _logger.LogInformation("End deleting...");
        return isSuccess ? NoContent() : NotFound();
    }
}
