using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class UserNotInsertedException : Exception
    {
        public UserNotInsertedException()
        {
        }

        public UserNotInsertedException(string message) : base(message)
        {
        }

        public UserNotInsertedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotInsertedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
