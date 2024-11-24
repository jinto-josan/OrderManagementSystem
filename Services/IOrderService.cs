using Domain.Entities;
using Infrastructure.Repositories;

namespace Services
{
    public interface IOrderService
    {


        public  Task<Order> CreateOrderAsync(Guid userId, List<OrderItem> orderItems);


        public  Task<bool> ValidateOrder(Order order);


        public  Task<Order> GetOrderByIdAsync(Guid orderId);

        public void TestInterface()
        {
            Console.WriteLine("Handled the method call");
        }
        
    }

}
