namespace Ordering.Application.Dtos
{
    public record OrderItemsDto
    (
        Guid OrderId,
        Guid ProductId,
        int Quantity,
        decimal Price
    );
}
