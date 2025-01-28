

using Pedidos.Core.Entities;

namespace Pedidos_Application.Model
{
    public class OrderItemViemModel
    {
        public OrderItemViemModel(int id, string product, int quantity, string clientDoc, string clientName, double price)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            ClientDoc = clientDoc;
            ClientName = clientName;
            Price = price;
            TotalCost = (quantity*price);
        }

        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public static OrderItemViemModel FromEntityOrder(Order order)
            => new (order.Id, order.Product, order.Quantity, order.ClientDoc, order.ClientName, order.Price);
    }
}
