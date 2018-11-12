using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSlicer.Core.Util
{
    internal static class Extensions
    {
        public static Tuple<T1, T2>[] ToTupleArray<T1, T2>
            (this ConcurrentDictionary<T1, T2> valuePairs)
        {
            return valuePairs.Select(x => (x.Key, x.Value).ToTuple()).ToArray();
        }

        public static ConcurrentDictionary<T1, T2> ToConcurrentDictionary
            <T1, T2>(this Tuple<T1, T2>[] tupleArray)
        {
            return new ConcurrentDictionary<T1, T2>
                (tupleArray.ToDictionary(x => x.Item1, x => x.Item2));
        }

        public static ConcurrentDictionary<T1, T2> Merge<T1, T2>
            (this ConcurrentDictionary<T1, T2> current, ConcurrentDictionary<T1, T2> merging)
        {
            var dict = current.ToDictionary(x => x.Key, x => x.Value);

            merging.ToList().ForEach(x => 
            {
                if (dict.ContainsKey(x.Key))
                {
                    dict[x.Key] = x.Value;
                }
                else
                {
                    dict.Add(x.Key, x.Value);
                }
            });

            return new ConcurrentDictionary<T1, T2>(dict);
        }
    }
}
