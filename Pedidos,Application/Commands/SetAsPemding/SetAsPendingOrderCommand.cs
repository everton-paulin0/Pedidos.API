using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.SetAsPemding
{
    public class SetAsPendingOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public SetAsPendingOrderCommand(int id)
        {
            Id = id;
        }
    }
}
