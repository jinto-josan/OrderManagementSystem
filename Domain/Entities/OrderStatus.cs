using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public enum OrderStatus
    {
        Pending,
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
