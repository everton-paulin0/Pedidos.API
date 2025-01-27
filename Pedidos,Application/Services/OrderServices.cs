using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pedidos.Infraestucture;
using Pedidos_Application.Model;
using Pedidos_Application.Services.Interfaces;

namespace Pedidos_Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();
            _context.Orders.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<OrderItemViemModel>> GetAll(string search = "")
        {
            var orders = _context.Orders.Where(o => !o.IsDeleted && (search == "" || o.Product.Contains(search)))
                .ToList();

            var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


            return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
        }

        public ResultViewModel<OrderViewModel> GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            var model = OrderViewModel.FromEntityOrder(order);

            return ResultViewModel<OrderViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateOrderInputModel model)
        {
            var order = model.ToEntityOrder();

            _context.Orders.Add(order);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(order.Id);
        }

        
        public ResultViewModel Update(UpdateOrderInputModel model)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == model.IdOrder);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Update(model.Product, model.Quantity,model.ClientName, model.ClientDoc, model.Price, model.TotalCost);

            _context.Orders.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
