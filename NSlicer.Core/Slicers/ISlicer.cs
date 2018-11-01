using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Slicers
{
    /// <summary>
    /// Make decomposition of complex object on smaller slices.
    /// </summary>
    /// <typeparam name="TComposite">Complex data type</typeparam>
    public interface ISlicer<TComposite>
    {
        (T1, T2) Slice<T1, T2>(TComposite data);
        (T1, T2, T3) Slice<T1, T2, T3>(TComposite data);
        (T1, T2, T3, T4) Slice<T1, T2, T3, T4>(TComposite data);
        object[] Slice(TComposite data, Type[] sliceTypes);
        object[] Slice(TComposite data);

        void Slice<T1, T2>(TComposite data, out T1 firstSlice, out T2 secondSlice);
        void Slice<T1, T2, T3>(TComposite data, out T1 firstSlice, out T2 secondSlice,
            out T3 thirdSlice);

        void Slice<T1, T2, T3, T4>(TComposite data, out T1 firstSlice, out T2 secondSlice,
            out T3 thirdSlice, out T4 fourthSlice);

        void Slice(TComposite data, out object[] slices);
    }
}
