using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public DeleteOrderHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
