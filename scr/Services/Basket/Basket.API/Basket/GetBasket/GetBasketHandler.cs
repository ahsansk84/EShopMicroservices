
namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(IEnumerable<ShoppingCart> Cart);

    internal class GetBasketQueryHandler(IDocumentSession session)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var shoppingCart = await session.Query<ShoppingCart>()
                .ToListAsync(cancellationToken);

            return new GetBasketResult(shoppingCart);
        }
    }
}
