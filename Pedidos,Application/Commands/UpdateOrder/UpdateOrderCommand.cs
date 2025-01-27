
using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ResultViewModel>
    {
        public int IdOrder { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
    }
}
