using System;
using System.Runtime.Serialization;

namespace djfoxer.PiHole.AdFilterSet.Exceptions
{
    [Serializable]
    public class MissingHostException : Exception
    {
        public MissingHostException()
        {
        }

        public MissingHostException(string message) : base(message)
        {
        }

        public MissingHostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingHostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
