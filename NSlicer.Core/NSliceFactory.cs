using NSlicer.Core.Mappers;
using NSlicer.Core.Slicers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NSlicer.Core
{
    public static class NSliceFactory
    {
        private static readonly ConcurrentDictionary
            <Tuple<Type, Type>, object> _createdMappers;
        private static readonly ConcurrentDictionary
            <Type, object> _createdSlicers;
        
        static NSliceFactory()
        {
            _createdMappers = new ConcurrentDictionary<Tuple<Type, Type>, object>();
            _createdSlicers = new ConcurrentDictionary<Type, object>();
        }

        public static ISlicer<TComposite> SlicerFor<TComposite>() 
            => (ISlicer<TComposite>)_createdSlicers.GetOrAdd(typeof(TComposite),
                new Slicer<TComposite>());

        public static IMapper<TFirst, TSecond> MapperFor<TFirst, TSecond>() 
            where TFirst : class where TSecond : class
            => (IMapper<TFirst, TSecond>)_createdMappers
                .GetOrAdd((typeof(TFirst), typeof(TSecond)).ToTuple(), 
                new Mapper<TFirst, TSecond>());

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
