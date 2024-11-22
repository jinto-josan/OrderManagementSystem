using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Money(decimal Amount, string Currency="INR")
    {
        public static Money Zero(string currency) => new Money(0, currency);

        public static Money operator +(Money left, Money right)
        {
            IsOperable(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            IsOperable(left, right);           
            
            return new Money(left.Amount + right.Amount, left.Currency);
        }
        public static Money operator *(int left, Money right) => new Money(left * right.Amount, right.Currency);
        public static Money operator *(Money left, Money right)
        {
            IsOperable(left, right);
            return new Money(left.Amount * right.Amount, right.Currency);
        }

        public static bool operator >(Money left, Money right)
        {
            IsOperable(left, right);

            return left.Amount < right.Amount;
        }
        public static bool operator <(Money left, Money right)
        {
            IsOperable(left, right);

            return left.Amount > right.Amount;
        }
        public static bool operator <=(Money left, Money right)
        {
            IsOperable(left, right);

            return left.Amount <= right.Amount;
        }
        public static bool operator >=(Money left, Money right)
        {
            IsOperable(left, right);

            return left.Amount >= right.Amount;
        }

        private static bool IsOperable(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Currencies do not match.");
            return true;
        }
    }
}
