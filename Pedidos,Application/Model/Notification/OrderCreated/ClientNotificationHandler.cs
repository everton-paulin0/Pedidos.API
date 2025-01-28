using MediatR;

namespace Pedidos_Application.Model.Notification.OrderCreated
{
    public class ClientNotificationHandler : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"O Pedido - {notification.Id} - Cliente : {notification.ClientName} no Valor R$ {notification.TotalCost}, foi emitido com sucesso.");

            return Task.CompletedTask;
        }
    }
}

