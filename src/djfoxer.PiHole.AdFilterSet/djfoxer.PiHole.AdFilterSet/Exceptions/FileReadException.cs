using System;
using System.Runtime.Serialization;

namespace djfoxer.PiHole.AdFilterSet.Exceptions
{
    public class FileReadException : Exception
    {
        public FileReadException()
        {
        }

        public FileReadException(string message) : base(message)
        {
        }

        public FileReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
