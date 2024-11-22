using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReturnOrder:Order
    {
        public DateTime ReturnDate {  get; set; }
        public string? Reason {  get; set; }

        public Guid OrderRef {  get; init; }

        public ReturnOrder(Order order)
        {
            OrderRef=order.Id;
            SetStatus(OrderStatus.ReturnProcessing);
        }

        public void RejectReturn()=> SetStatus(OrderStatus.ReturnRejected);
        
    }
}
