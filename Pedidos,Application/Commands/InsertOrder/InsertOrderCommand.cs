using MediatR;
using Pedidos.Core.Entities;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.InsertOrder
{
    public class InsertOrderCommand : IRequest<ResultViewModel<int>>
    {
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
