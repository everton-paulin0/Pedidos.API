
using Pedidos.Core.Enum;

namespace Pedidos.Core.Entities
{
    public class Order : BaseEntities
    {
        public Order()
        {
            
        }
        public Order(string product, int quantity, string clientDoc, string clientName, double price, double totalCost)
        {
            Product = product;
            Quantity = quantity;
            ClientDoc = clientDoc;
            ClientName = clientName;
            Price = price;
            TotalCost = (quantity*price);
            Status = OrderStatus.Started;
        }

        public string Product { get; set; }
        public int Quantity { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }        
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public OrderStatus Status { get; set; }

        public void Update(string product, int quantity, string clientdoc, string clientName, double price, double totalCost)
        {
            Product = product;
            Quantity = quantity;
            ClientDoc = clientdoc;
            ClientName = clientName;
            Price = price;
            TotalCost = totalCost;
            UpdatedAt = DateTime.Now;
        }

        public void Complete()
        {
            if (Status != OrderStatus.PaymentPending && Status != OrderStatus.Fronzen && Status != OrderStatus.Cancelled)
            {
                Status = OrderStatus.Finished;
                UpdatedAt = DateTime.Now;
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Started || Status == OrderStatus.Fronzen)
            {
                Status = OrderStatus.Cancelled;
                UpdatedAt = DateTime.Now;
            }
        }



        public void SetPaymentPending()
        {
            if (Status == OrderStatus.Started && Status != OrderStatus.Finished)
            {
                Status = OrderStatus.PaymentPending;
                UpdatedAt = DateTime.Now;
            }
        }
    }
}
