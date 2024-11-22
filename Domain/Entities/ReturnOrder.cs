using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class ReturnOrder:Order
    {
        public DateTime ReturnDate {  get; set; }
        public string? Reason {  get; set; }

        public Guid OrderRef {  get; init; }

        public ReturnOrder()
        {//order reference not set
            SetStatus(OrderStatus.ReturnProcessing);
        }

        public void RejectReturn()=> SetStatus(OrderStatus.ReturnRejected);
        
    }
}
