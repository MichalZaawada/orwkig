namespace MyList.Api.Commands;

public record AddProductCommand(
    string Description, 
    int Quantity
);