namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart)
        :ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can't be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("User Name is required")
                .Length(2, 20).WithMessage("User Name must be between 2 to 20 characters");
            RuleFor(x => x.Cart.Items.Count()).GreaterThan(0).WithMessage("Item must be greater than 0");
            RuleFor(x => x.Cart.TotalPrice).GreaterThan(0).WithMessage("Total Price  must be greater than 0");
        }
    }

    internal class StoreBasketCommandHandler(IBasketRepository repository)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //create Poduct entity from command objet
            //save to database
            //return StoreBasketResult result

            ShoppingCart cart = command.Cart;

            //TODO
            //save to databas
            await repository.StoreBasket(cart, cancellationToken);

            //return result

            return new StoreBasketResult(command.Cart.UserName);

        }
    }
}
