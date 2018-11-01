using NSlicer.Core.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NSlicer.Core.Exceptions
{
    public class MapperPropertyBindingException : NSlicerException
    {
        public MapperPropertyBindingException()
        {
        }

        public MapperPropertyBindingException(string message) : base(message)
        {
        }

        public MapperPropertyBindingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public MapperPropertyBindingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
