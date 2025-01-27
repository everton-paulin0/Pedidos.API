using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<ResultViewModel>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
