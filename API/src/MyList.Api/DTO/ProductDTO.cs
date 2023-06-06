namespace MyList.Api.DTO;

public sealed class ProductDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
