using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.SetAsPemding
{
    public class SetAsPendingOrderHandler : IRequestHandler<SetAsPendingOrderCommand, ResultViewModel>
    {
        public Task<ResultViewModel> Handle(SetAsPendingOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
