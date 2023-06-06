namespace MyList.Api.Entities;

public sealed class Product
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }

    public Product(string description, int quantity)
    {
        Id = Guid.NewGuid();
        Description = description;
        Quantity = quantity;
        CreatedOn = DateTimeOffset.Now;
    }

}
