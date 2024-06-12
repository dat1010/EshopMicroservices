namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler
    (IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationtoken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handler called with {@Query}", query);

        var products = await session.Query<Product>().ToListAsync(cancellationtoken);

        return new GetProductsResult(products);
    }
}
