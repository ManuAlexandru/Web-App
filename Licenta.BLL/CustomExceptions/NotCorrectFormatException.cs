using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class NotCorrectFormatException : Exception
    {
        public NotCorrectFormatException()
        {
        }

        public NotCorrectFormatException(string message) : base(message)
        {
        }

        public NotCorrectFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCorrectFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
