using MediatR;

namespace Pedidos_Application.Model.Notification.OrderCreated
{
    public class GenerateOrderBoardHandler : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Pedidos Gerados do Clinte: {notification.ClientName}");

            return Task.CompletedTask;
        }
    }
}
