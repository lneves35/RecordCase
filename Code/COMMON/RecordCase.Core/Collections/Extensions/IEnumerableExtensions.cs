using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordCase.Core.Collections.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEachInEnumerable<TEnumerable>(this IEnumerable<TEnumerable> enumerable, Action<TEnumerable> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
