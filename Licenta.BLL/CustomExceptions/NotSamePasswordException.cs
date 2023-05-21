using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class NotSamePasswordException : Exception
    {
        public NotSamePasswordException()
        {
        }

        public NotSamePasswordException(string message) : base(message)
        {
        }

        public NotSamePasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSamePasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
