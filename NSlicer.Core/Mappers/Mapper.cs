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
        private readonly Tuple<PropertyInfo, PropertyInfo>[] _firstFindedProperties;
        private readonly Tuple<PropertyInfo, PropertyInfo>[] _secondFindedProperties;
        private readonly ConcurrentDictionary<PropertyInfo, PropertyInfo> _bindedProperties;

        private readonly Type _firstType;
        private readonly Type _secondType;

        public Mapper()
        {
            _firstType = typeof(TFirst);
            _secondType = typeof(TSecond);

            _bindedProperties = new ConcurrentDictionary<PropertyInfo, PropertyInfo>();

            _firstFindedProperties = FindProperties(_firstType, _secondType).ToArray();
            _secondFindedProperties = FindProperties(_secondType, _firstType).ToArray();

        }

        public IMapper<TFirst, TSecond> AddPropertyBinding
            (string fromPropertyName, string toPropertyName)
        {


            return this;
        }

        public TFirst Map(TSecond from) 
            => Map(_secondType, from, _firstType, _firstFindedProperties) as TFirst;

        public TSecond Map(TFirst from)
            => Map(_firstType, from, _secondType, _secondFindedProperties) as TSecond;

        public IEnumerable<TFirst> Map(IEnumerable<TSecond> from)
        {
            foreach (var item in from)
                yield return Map(item);
        }

        public IEnumerable<TSecond> Map(IEnumerable<TFirst> from)
        {
            foreach (var item in from)
                yield return Map(item);
        }

        public IMapper<TFirst, TSecond> ResetPropertyBindings()
        {
            _bindedProperties.Clear();
            return this;
        }

        private IEnumerable<Tuple<PropertyInfo, PropertyInfo>> FindProperties(Type T, Type R)
        {
            var t_properties = T.GetProperties();
            var r_properties = R.GetProperties();

            foreach (var t_property in t_properties)
                foreach (var r_property in r_properties)
                    if (t_property.Name == r_property.Name)
                        yield return (t_property, r_property).ToTuple();
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
