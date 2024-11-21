using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }
        public OrderStatus Status { get; private set; }

        public void SetStatus(OrderStatus status) => Status = status;
    }
}
