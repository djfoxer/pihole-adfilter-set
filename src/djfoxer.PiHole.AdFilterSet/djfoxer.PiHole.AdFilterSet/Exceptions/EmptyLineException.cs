using System;
using System.Runtime.Serialization;

namespace djfoxer.PiHole.AdFilterSet.Exceptions
{
    [Serializable]
    public class EmptyLineException : Exception
    {
        public EmptyLineException()
        {
        }

        public EmptyLineException(string message) : base(message)
        {
        }

        public EmptyLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
