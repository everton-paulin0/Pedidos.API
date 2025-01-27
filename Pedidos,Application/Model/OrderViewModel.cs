using System.ComponentModel.DataAnnotations;
using Pedidos.Core.Entities;

namespace Pedidos_Application.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string product, int quantity, string clientName, string clientDoc, double price, double totalCost)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            ClientName = clientName;
            ClientDoc = clientDoc;
            Price = price;
            TotalCost = totalCost;
        }
        
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string ClientName { get; set; }
        public string ClientDoc { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public static OrderViewModel FromEntityOrder(Order entity)
            => new OrderViewModel (entity.Id, entity.Product, entity.Quantity, entity.ClientName, entity.ClientDoc, entity.Price, entity.TotalCost);
    }
}
