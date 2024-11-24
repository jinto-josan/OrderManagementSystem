using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enums
{
    public enum OrderStatus
    {
        Pending,
        Checkout,
        Paid,
        Shipped,
        InTransit,
        Delivered,
        //return states
        ReturnProcessing,
        ReturnApproved,
        ProductVerified,
        ReturnShipped,
        ReturnInTransit,
        Returned,
        ReturnRejected,
        Cancelled, // any time before 
    }
}
