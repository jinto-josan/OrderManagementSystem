using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class OrderStatusEvent:EventArgs
    {
        public Guid OrderId { get; init; }
        public OrderStatus OrderStatus { get; init; }
        public OrderStatusEvent(Guid orderId, OrderStatus status)
        {
            OrderId = orderId;
            OrderStatus=status;
        }
        public OrderStatusEvent() { }
    }
}
