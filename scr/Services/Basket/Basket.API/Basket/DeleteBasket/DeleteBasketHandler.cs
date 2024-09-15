namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : IQuery<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
        }
    }
    internal class DeleteBasketCommmandHandler(IDocumentSession session)
        : IQueryHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand commmand, CancellationToken cancellationToken)
        {
            session.Delete<ShoppingCart>(commmand.UserName);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
