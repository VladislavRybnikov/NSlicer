using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Mappers
{
    internal class Mapper<TFirst, TSecond> : IMapper<TFirst, TSecond>
    {
        public IMapper<TFirst, TSecond> AddPropertyBinding
            (string fromPropertyName, string toPropertyName)
        {
            throw new NotImplementedException();
        }

        public TFirst Map(TSecond from)
        {
            throw new NotImplementedException();
        }

        public TSecond Map(TFirst from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TFirst> Map(IEnumerable<TSecond> from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TSecond> Map(IEnumerable<TFirst> from)
        {
            throw new NotImplementedException();
        }

        public IMapper<TFirst, TSecond> ResetPropertyBindings()
        {
            throw new NotImplementedException();
        }
    }
}
