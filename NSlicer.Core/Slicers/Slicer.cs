using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Slicers
{
    internal class Slicer<TComposite> : ISlicer<TComposite>
    {
        public (T1, T2) Slice<T1, T2>(TComposite data)
        {
            throw new NotImplementedException();
        }

        public (T1, T2, T3) Slice<T1, T2, T3>(TComposite data)
        {
            throw new NotImplementedException();
        }

        public (T1, T2, T3, T4) Slice<T1, T2, T3, T4>(TComposite data)
        {
            throw new NotImplementedException();
        }

        public object[] Slice(TComposite data, Type[] sliceTypes)
        {
            throw new NotImplementedException();
        }

        public void Slice<T1, T2>(TComposite data, out T1 firstSlice, out T2 secondSlice)
        {
            throw new NotImplementedException();
        }

        public void Slice<T1, T2, T3>(TComposite data, out T1 firstSlice, out T2 secondSlice, out T3 thirdSlice)
        {
            throw new NotImplementedException();
        }

        public void Slice<T1, T2, T3, T4>(TComposite data, out T1 firstSlice, out T2 secondSlice, out T3 thirdSlice, out T4 fourthSlice)
        {
            throw new NotImplementedException();
        }

        public void Slice(TComposite data, out object[] slices)
        {
            throw new NotImplementedException();
        }
    }
}
