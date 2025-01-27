using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.CompleteOrder
{
    
    public class CompleteOrderHandler : IRequestHandler<CompleteOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public CompleteOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
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
