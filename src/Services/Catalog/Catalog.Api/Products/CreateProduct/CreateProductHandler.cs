namespace Catalog.Api.Products.CreateProduct;

using BuildingBlocks.CQRS;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken token)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // TODO
        // save to database

        return new CreateProductResult(Guid.NewGuid());
    }

}
