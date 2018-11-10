using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Composers
{
    internal class Composer<TData> : IComposer<TData> where TData : class
    {
        public Composer()
        {

        }

        public IComposer<TData> AddPropertyBinding(string fromProperty, string toProperty)
        {
            throw new NotImplementedException();
        }

        public TData Compose(params object[] args)
        {


            throw new NotImplementedException();
        }
    }
}
