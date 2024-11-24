using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    
    public class TransactionStatusEvent
    {
        public Guid TransactionID { get; init; }
        public TransactionStatusEvent(Guid transactionID)
        {
            TransactionID=transactionID;
        }
    }
}
