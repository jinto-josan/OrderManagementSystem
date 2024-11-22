using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class MoneyExtensions
    {

        public static Money Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Money> selector)
        {
            var first=selector(source.First());
            Money accum=first;
            foreach (var item in source)
            {
                accum+=selector(item);
                
            }
            return accum - first;
        }

    }
}
