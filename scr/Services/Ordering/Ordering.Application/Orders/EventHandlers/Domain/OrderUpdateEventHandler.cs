﻿namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderUpdateEventHandler(ILogger<OrderUpdateEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handler: {DomanEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
