namespace CatalogAPI.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id): IQuery<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
    internal class DeleteProductCommmandHandler(IDocumentSession session)
        : IQueryHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand commmand, CancellationToken cancellationToken)
        {
            session.Delete<Product>(commmand.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
