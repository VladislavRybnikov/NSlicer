using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Mappers
{
    public interface IMapper<TFirst, TSecond> where TFirst : class where TSecond : class
    {
        TFirst Map(TSecond from);
        TSecond Map(TFirst from);

        IEnumerable<TFirst> Map(IEnumerable<TSecond> from);
        IEnumerable<TSecond> Map(IEnumerable<TFirst> from);

        IMapper<TFirst, TSecond> AddPropertyBinding
            (string fromPropertyName, string toPropertyName);
        IMapper<TFirst, TSecond> AddPropertyBinding

            (Func<TFirst, object> from, Func<TSecond, object> to);
        IMapper<TFirst, TSecond> AddPropertyBinding
            (Func<TSecond, object> from, Func<TFirst, object> to);

        IMapper<TFirst, TSecond> ResetPropertyBindings();
    }
}
