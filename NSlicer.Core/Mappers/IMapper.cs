using System;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core.Mappers
{
    public interface IMapper<TFirst, TSecond>
    {
        TFirst Map(TSecond from);
        TSecond Map(TFirst from);

        IEnumerable<TFirst> Map(IEnumerable<TSecond> from);
        IEnumerable<TSecond> Map(IEnumerable<TFirst> from);
    }
}
