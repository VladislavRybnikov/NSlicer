using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NSlicer.Core.Mappers
{
    internal class Mapper<TFirst, TSecond> : IMapper<TFirst, TSecond>
    {
        private readonly PropertyInfo[] _findedProperties;
        private readonly ConcurrentDictionary<PropertyInfo, PropertyInfo> _bindedProperties;

        private readonly Type _firstType;
        private readonly Type _secondType;

        public Mapper()
        {
            _bindedProperties = new ConcurrentDictionary<PropertyInfo, PropertyInfo>();
        }

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
            _bindedProperties.Clear();
            return this;
        }
    }
}
