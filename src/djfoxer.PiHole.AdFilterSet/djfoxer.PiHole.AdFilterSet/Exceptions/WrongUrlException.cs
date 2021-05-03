using System;
using System.Runtime.Serialization;

namespace djfoxer.PiHole.AdFilterSet.Exceptions
{
    public class WrongUrlException : Exception
    {
        public WrongUrlException()
        {
        }

        public WrongUrlException(string message) : base(message)
        {
        }

        public WrongUrlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongUrlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
