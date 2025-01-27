using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}
