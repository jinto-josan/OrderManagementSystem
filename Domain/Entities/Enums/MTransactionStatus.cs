using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enums
{
    public enum MTransactionStatus
    {
        Processing, //Payment process has started
        Expired,    //User didnt authorize the transfer before time expiry
        Declined,   //Insufficient funds or some reason bank didnt agree
        Authorized, //Bank authorized transfer
        Voided,     //Cancelled after authorization
        Captured,   //Fund transferred to the seller
        Success,    //Processed and Captured
        Failed,     //Incorrect payment details, or an error during processing like network error
        Cancelled, //Processed and authorized
        Refunded,   //On Dispute fund returned
        PartiallyRefunded,  //Partial refund
        ChargeBack, //Reversal of payment by credit card issuer due to fraud, initiated by cardholder


    }
}
