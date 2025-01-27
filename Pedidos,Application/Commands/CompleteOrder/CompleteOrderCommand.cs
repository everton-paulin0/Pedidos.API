using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.CompleteOrder
{
    public class CompleteOrderCommand : IRequest<ResultViewModel>
    {
        public CompleteOrderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
