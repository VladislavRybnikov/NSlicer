using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NSlicer.Core.Exceptions.Base
{
    public abstract class NSlicerException : Exception
    {
        public NSlicerException()
        {
        }

        public NSlicerException(string message) : base(message)
        {
        }

        public NSlicerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NSlicerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
