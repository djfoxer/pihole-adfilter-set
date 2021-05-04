using System;
using System.Runtime.Serialization;

namespace djfoxer.PiHole.AdFilterSet.Exceptions
{
    [Serializable]
    public class DuplicateLineException : Exception
    {
        public DuplicateLineException()
        {
        }

        public DuplicateLineException(string message) : base(message)
        {
        }

        public DuplicateLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
