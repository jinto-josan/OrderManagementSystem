using Application.Entities;
using Application.Extensions;
using Application.ValueObjects; 

namespace OrderManagement.Application.Services
{
    public class PaymentService
    {
        public bool ProcessPayment(Order order, Money payment)
        {
            if (order.Status == OrderStatus.Paid)
                throw new InvalidOperationException("Order already paid.");

            Money totalAmount = order.OrderItems.Sum(item => item.Quantity * item.Product.Price);
            if (payment >= totalAmount)
            {
                //order.SetStatus(OrderStatus.Paid);
                return true;
            }

            return false;
        }
    }
}
