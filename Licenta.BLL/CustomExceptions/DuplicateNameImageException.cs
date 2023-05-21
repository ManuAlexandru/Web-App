using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class DuplicateNameImageException : Exception
    {
        public DuplicateNameImageException()
        {
        }

        public DuplicateNameImageException(string message) : base(message)
        {
        }

        public DuplicateNameImageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateNameImageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
