namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreateEventHandler(ILogger<OrderCreateEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handler: {DomanEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
