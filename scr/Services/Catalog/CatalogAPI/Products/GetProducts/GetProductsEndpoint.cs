namespace CatalogAPI.Products.GetProducts
{
    public record GettProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GettProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GettProductsRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GettProductsResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .Produces<GettProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}
