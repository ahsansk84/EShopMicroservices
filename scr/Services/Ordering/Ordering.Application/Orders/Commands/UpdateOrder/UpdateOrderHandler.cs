namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            //Update Order entity from command object
            //save to database
            //return result
            var orderId = OrderId.Of(command.Order.Id);
            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundExcption(command.Order.Id);
            }
            UpdateOrderWithNewValues(order, command.Order);

            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateOrderResult(true);
        }

        private void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
        {
            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);
            var billingAddress = Address.Of(orderDto.BullingAddress.FirstName, orderDto.BullingAddress.LastName, orderDto.BullingAddress.EmailAddress, orderDto.BullingAddress.AddressLine, orderDto.BullingAddress.Country, orderDto.BullingAddress.State, orderDto.BullingAddress.ZipCode);
            var payment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod);

            order.Update(
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: payment,
                status: orderDto.Status
                );

            //foreach (var orderItemDto in orderDto.OrderItems)
            //{
            //    order.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
            //}
        }
    }


}
