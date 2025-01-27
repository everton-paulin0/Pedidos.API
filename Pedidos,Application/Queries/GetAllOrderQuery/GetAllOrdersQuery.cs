using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Queries.GetAllOrderQuery
{
    public class GetAllOrdersQuery : IRequest<ResultViewModel<List<OrderItemViemModel>>>
    {
        public GetAllOrdersQuery()
        {
            
        }
        public class GetAllordesHandler : IRequestHandler<GetAllOrdersQuery, ResultViewModel<List<OrderItemViemModel>>>
        {
            private readonly AppDbContext _context;
            public GetAllordesHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<List<OrderItemViemModel>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders.Where(o => !o.IsDeleted).ToListAsync();

                var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


                return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
            }
        }
    }
}
