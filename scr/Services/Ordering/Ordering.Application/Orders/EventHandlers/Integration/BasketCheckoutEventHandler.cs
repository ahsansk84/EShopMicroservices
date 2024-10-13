using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutEventHandler
        (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            // TODO: Create new order and start order fullfilment process
            logger.LogInformation("Integration Event handler: {IntegrationEvent}", context);

            var command = MapToCreateOrderCommannd(context.Message);
            await sender.Send(command);

        }

        private CreateOrderCommand MapToCreateOrderCommannd(BasketCheckoutEvent message)
        {
            var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddres, message.AddressLine, message.Country, message.State, message.ZipCode);
            var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BullingAddress: addressDto,
                Payment: paymentDto,
                Status: Ordering.Domain.Enums.OrderStatus.Pending,
                OrderItems:
                [
                    new OrderItemDto(orderId, new Guid("6eaa68ca-6f49-42ad-bb20-b160ea60cc82"), 2, 100),
                    new OrderItemDto(orderId, new Guid("0191dc08-0b01-4d69-a825-c9310d5b349a"), 1, 700)

                ]);
            
            return new CreateOrderCommand(orderDto);
        }
    }
}
