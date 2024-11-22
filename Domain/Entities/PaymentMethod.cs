using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        EWallet,
        BankTransfer,
        BNPL,
        Crypto,
        CoD
    }
}
