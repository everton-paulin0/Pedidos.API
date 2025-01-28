using MediatR;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;
using Pedidos_Application.Model.Notification.OrderCreated;

namespace Pedidos_Application.Commands.InsertOrder
{
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public InsertOrderHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntityOrder();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var orderCreatead = new OrderCreatedNotification(order.Id, order.ClientName, order.TotalCost);

            await _mediator.Publish(orderCreatead);

            return ResultViewModel<int>.Sucess(order.Id);
        }
    }
}
