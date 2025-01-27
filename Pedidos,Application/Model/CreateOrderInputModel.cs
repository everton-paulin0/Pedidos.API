using System.ComponentModel.DataAnnotations;
using Pedidos.Core.Entities;

namespace Pedidos_Application.Model
{
    public class CreateOrderInputModel
    {
        [Required]
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public Order ToEntityOrder()
            => new Order(Product, Quantity, ClientDoc, ClientName, Price, TotalCost);
    }
}
