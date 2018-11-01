using NSlicer.Core.Mappers;
using NSlicer.Core.Slicers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core
{
    public static class NSlicer
    {
        private static readonly ConcurrentDictionary
            <Tuple<Type, Type>, IMapper<object, object>> _createdMappers;
        private static readonly ConcurrentDictionary
            <Type, ISlicer<object>> _createdSlicers;
        
        static NSlicer()
        {
            _createdMappers = new ConcurrentDictionary<Tuple<Type, Type>, IMapper<object, object>>();
            _createdSlicers = new ConcurrentDictionary<Type, ISlicer<object>>();
        }

        public static ISlicer<TComposite> SlicerFor<TComposite>() 
            => (ISlicer<TComposite>)_createdSlicers.GetOrAdd(typeof(TComposite),
                (ISlicer<object>)new Slicer<TComposite>());

        public static IMapper<TFirst, TSecond> MapperFor<TFirst, TSecond>() 
            => (IMapper<TFirst, TSecond>)_createdMappers
                .GetOrAdd((typeof(TFirst), typeof(TSecond)).ToTuple(),
                (IMapper<object, object>)new Mapper<TFirst, TSecond>());

        #region Clean Up

        public static void ClearMappers()
        {
            _createdMappers.Clear();
        }
        public static void ClearSlicers()
        {
            _createdSlicers.Clear();
        }

        public static void Clear()
        {
            ClearMappers();
            ClearSlicers();
        } 

        #endregion
    }
}
