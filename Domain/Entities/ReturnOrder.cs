using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class ReturnOrder:Order
    {
        public DateTime ReturnDate {  get; set; }
        public string? Reason {  get; set; }

        public Guid OrderRef {  get; private set; }

        public ReturnOrder():base(OrderStatus.ReturnProcessing)
        { //Todo: Order id to reference set pending
        }

        public void SetOrderRef(Guid orderRef) => OrderRef = orderRef;
       

        public void RejectReturn()=> SetStatus(OrderStatus.ReturnRejected);
        
    }
}
