using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public sealed class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
