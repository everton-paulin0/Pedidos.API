using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Pedidos.Infraestucture;
using Pedidos_Application.Model;

namespace Pedidos_Application.Commands.InsertOrder
{
    public class ValidateInsertOrderCommandBevahior : IPipelineBehavior<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        public ValidateInsertOrderCommandBevahior(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var quantities = _context.Orders.Any(o => o.Quantity > 0);

            if (!quantities)
            {
                return ResultViewModel<int>.Error("Quantidade inválida");
            }
            return await next();
        }
    }
}
