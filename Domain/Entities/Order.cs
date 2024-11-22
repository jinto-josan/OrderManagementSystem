using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }
        public OrderStatus Status { get; private set; }

        public void UpdateStatus()
        {
            //No update after terminal status. And it ensures status should be updated only incremental
            if (this.Status is (OrderStatus.Shipped or OrderStatus.Returned or OrderStatus.Cancelled or OrderStatus.ReturnRejected))
                throw new InvalidOperationException("Order is in its final state.");                
            this.Status= (OrderStatus)( (int)Status + 1);

        }
        public void CancelOrder()
        {//Cancel only if its not shipped or return is in processing state
            if (Status is (OrderStatus.Shipped or (> OrderStatus.ReturnProcessing))) 
                throw new InvalidOperationException("Order cant be cancelled after shipped, please return it");    
            this.Status=OrderStatus.Cancelled;
        }

        protected void SetStatus(OrderStatus status) => Status = status;
        
    }
}
