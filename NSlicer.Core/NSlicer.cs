﻿using NSlicer.Core.Mappers;
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

        public static void Initialize()
        {

        }

        public static void Clear()
        {

        }

        public static ISlicer<TComposite> SlicerFor<TComposite>()
        {
            throw new Exception();
        }

        public static IMapper<TFirst, TSecond> MapperFor<TFirst, TSecond>()
        {
            throw new Exception();
        }

    }
}