using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos
{
    public record OrderDto
    (
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BullingAddress,
        PaymentDto Payment,
        OrderStatus Status,
        List<OrderItemsDto> OrderItems
     );
    
}
