using Domain.Events;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.EventInfra;

namespace Services.EventHandler
{
    public class OrderEventHandlers: IEagerSingleton
    {
        private readonly IServiceProvider _serviceProvider;

       
        public OrderEventHandlers(IServiceProvider serviceProvider, EventPublisher<OrderStatusEvent> orderStatusUpdateCommand) {
            _serviceProvider=serviceProvider;
            orderStatusUpdateCommand.Subscribe(HandleOrderStatusUpdate);
        }

        void HandleOrderStatusUpdate(object sender, OrderStatusEvent e)
        {
            switch (e.OrderStatus)
            {
                case OrderStatus.Checkout: { HandleCheckoutOrder(e); break; }
                case OrderStatus.Pending: { HandleCheckoutOrder(e); break; }
                default: { Console.WriteLine(e.OrderStatus); break; }
            }

        }
        void HandleCheckoutOrder(OrderStatusEvent e)
        {
            Console.WriteLine(e.OrderStatus);
            using (var scope = _serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IOrderService>().TestInterface();

            }
        }

    }
}
