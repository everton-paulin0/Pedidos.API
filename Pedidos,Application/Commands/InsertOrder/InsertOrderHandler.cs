using MediatR;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.InsertOrder
{
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        public InsertOrderHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntityOrder();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(order.Id);
        }
    }
}
