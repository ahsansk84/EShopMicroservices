
namespace CatalogAPI.Products.DeleteProduct
{
    public record DeleteProductCommmand(Guid Id): IQuery<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);


    internal class DeleteProductCommmandHandler
        (IDocumentSession session, ILogger<DeleteProductCommmandHandler> logger)
        : IQueryHandler<DeleteProductCommmand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommmand commmand, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommmandHandler.Handel called with {query}", commmand);

            session.Delete<Product>(commmand.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
