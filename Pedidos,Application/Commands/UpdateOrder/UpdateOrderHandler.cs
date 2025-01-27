using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public UpdateOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.IdOrder);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Update(request.Product, request.Quantity, request.ClientName, request.ClientDoc, request.Price, request.TotalCost);

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    
    }
}
