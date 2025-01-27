using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public CancelOrderHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            order.Complete();

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
