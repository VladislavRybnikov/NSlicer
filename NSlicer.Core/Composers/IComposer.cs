using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Composers
{
    public interface IComposer<TData> where TData : class
    {
        IComposer<TData> AddPropertyBinding(string fromProperty, string toProperty);
        TData Compose(params object[] args);
    }
}
