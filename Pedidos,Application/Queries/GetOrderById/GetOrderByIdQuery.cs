using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Pedidos_Application.Model;

namespace Pedidos_Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<ResultViewModel<OrderViewModel>>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
