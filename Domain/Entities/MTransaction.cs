using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    public class MTransaction
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Money Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public PaymentMethod method { get; set; }
        public string? PaymentReference { get; set; }

    }
}
