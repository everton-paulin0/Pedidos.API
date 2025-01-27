
using Pedidos_Application.Model;

namespace Pedidos_Application.Services.Interfaces
{
    public interface IOrderServices
    {
        ResultViewModel<List<OrderItemViemModel>> GetAll(string search = "");
        ResultViewModel<OrderViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateOrderInputModel model);
        ResultViewModel Update(UpdateOrderInputModel model);
        ResultViewModel Delete(int id);
        

    }
}
