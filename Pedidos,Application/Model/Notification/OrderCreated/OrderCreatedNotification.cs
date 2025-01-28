using MediatR;

namespace Pedidos_Application.Model.Notification.OrderCreated
{
    public class OrderCreatedNotification : INotification
    {
        public OrderCreatedNotification(int id, string clientName, double totalCost)
        {
            Id = id;
            ClientName = clientName;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string ClientName { get; set; }        
        public double TotalCost { get; set; }
    }
}
