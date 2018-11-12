using NSlicer.Core.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NSlicer.Core.Mappers
{
    internal class Mapper<TFirst, TSecond> : IMapper<TFirst, TSecond> 
        where TFirst : class where TSecond : class
    {
        private readonly Tuple<PropertyInfo, PropertyInfo>[] _tFirstFindedProperties;
        private readonly Tuple<PropertyInfo, PropertyInfo>[] _tSecondFindedProperties;

        private readonly ConcurrentDictionary<PropertyInfo, PropertyInfo> _tFirstBindedProperties;
        private readonly ConcurrentDictionary<PropertyInfo, PropertyInfo> _tSecondBindedProperties;

        private readonly ConcurrentDictionary<PropertyInfo, object> _tFirstBindings;
        private readonly ConcurrentDictionary<PropertyInfo, object> _tSecondBindings;

        private readonly Type _firstType;
        private readonly Type _secondType;

        public Mapper()
        {
            _firstType = typeof(TFirst);
            _secondType = typeof(TSecond);

            _tFirstBindedProperties = new ConcurrentDictionary<PropertyInfo, PropertyInfo>();
            _tSecondBindedProperties = new ConcurrentDictionary<PropertyInfo, PropertyInfo>();

            _tFirstBindings = new ConcurrentDictionary<PropertyInfo, object>();
            _tSecondBindings = new ConcurrentDictionary<PropertyInfo, object>();

            _tFirstFindedProperties = FindProperties(_firstType, _secondType).ToArray();
            _tSecondFindedProperties = FindProperties(_secondType, _firstType).ToArray();

        }

        public IMapper<TFirst, TSecond> AddPropertyBinding
            (string fromPropertyName, string toPropertyName)
        {
            return this;
        }

        public IMapper<TFirst, TSecond> AddPropertyBinding
            (Func<TFirst, object> from, Func<TSecond, object> to)
        {
            throw new NotImplementedException();
        }

        public IMapper<TFirst, TSecond> AddPropertyBinding
            (Func<TSecond, object> from, Func<TFirst, object> to)
        {
            throw new NotImplementedException();
        }

        public TFirst Map(TSecond from)
        {
            return Map(_secondType, from, _firstType, 
                PropertyBindingsFor<TFirst>()) as TFirst;
        }

        public TSecond Map(TFirst from)
        {
            return Map(_firstType, from, _secondType, 
                PropertyBindingsFor<TSecond>()) as TSecond;
        }

        public IEnumerable<TFirst> Map(IEnumerable<TSecond> from)
        {
            foreach (var item in from)
            {
                yield return Map(item);
            }
        }

        public IEnumerable<TSecond> Map(IEnumerable<TFirst> from)
        {
            foreach (var item in from)
            {
                yield return Map(item);
            }
        }

        public IMapper<TFirst, TSecond> ResetPropertyBindings()
        {
            _tFirstBindedProperties.Clear();
            return this;
        }

        private Tuple<PropertyInfo, PropertyInfo>[] PropertyBindingsFor<T>()
        {
            switch(typeof(T))
            {
                case TFirst first:
                    return _tSecondFindedProperties.ToConcurrentDictionary()
                .Merge(_tSecondBindedProperties).ToTupleArray();
                case TSecond second:
                    return _tFirstFindedProperties.ToConcurrentDictionary()
                .Merge(_tFirstBindedProperties).ToTupleArray();
                default:
                    throw null;
            }
        }

        private IEnumerable<Tuple<PropertyInfo, PropertyInfo>> FindProperties(Type T, Type R)
        {
            var t_properties = T.GetProperties();
            var r_properties = R.GetProperties();

            foreach (var t_property in t_properties)
            {
                foreach (var r_property in r_properties)
                {
                    if (t_property.Name == r_property.Name)
                    {
                        yield return (t_property, r_property).ToTuple();
                    }
                }
            }
        }

        private object Map
            (
            Type inputType,
            object inputValue,
            Type outputType,
            Tuple<PropertyInfo, PropertyInfo>[] bindedProperties
            )
        {
            var outputValue = outputType
                .GetConstructor(new Type[0]).Invoke(null);

            foreach (var pair in bindedProperties)
            {
                var name = pair.Item1.Name;

                if (pair.Item1.PropertyType == pair.Item2.PropertyType)
                {
                    outputType
                        .GetProperty(name)
                        .SetValue
                        (
                            outputValue,
                            inputType
                            .GetProperty(name)
                            .GetValue(inputValue)
                        );
                }
                else
                {
                    try
                    {
                        var value = inputType.GetProperty(name).GetValue(inputValue);
                        var property = outputType.GetProperty(name);
                        var propertyType = property.PropertyType;

                        property
                       .SetValue
                       (outputValue, Convert.ChangeType(value, propertyType));
                    }
                    catch { }
                }

            }

            return outputValue;
        }

    }
}
