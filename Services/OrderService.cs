using Domain.Entities;
using Infrastructure.Repositories;

namespace Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrderAsync(Guid userId, List<OrderItem> orderItems)
        {
            var order = new Order(OrderStatus.Pending)
            {
                UserId = userId,
                OrderItems = orderItems
            };

            if(await ValidateOrder(order))
                await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<bool> ValidateOrder(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product.Stock < item.Quantity)
                {
                    throw new Exception($"Not enough stock for product {product.Name}");
                }
            }
            return true;
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }
    }

}
