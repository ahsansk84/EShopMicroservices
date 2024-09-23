using Discount.Grpc;

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

    internal class StoreBasketCommandHandler
        (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //Communnicate with Discount.Grpc and calculate latest price for product

            await DecuctDiscount(command.Cart, cancellationToken);

            //TODO
            //save to databas - use marton upate if exist, if not exist add. 
            await repository.StoreBasket(command.Cart, cancellationToken);

            //return result

            return new StoreBasketResult(command.Cart.UserName);

        }
        private async Task DecuctDiscount(ShoppingCart Cart, CancellationToken cancellationToken)
        {
            foreach (var item in Cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(
                    new GetDiscountRequest { ProductName = item.ProductName },
                    cancellationToken : cancellationToken);
                item.Price -= coupon.Amount;
            }

        }
    }
}
