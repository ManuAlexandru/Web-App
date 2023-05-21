using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public sealed class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException()
        {
        }

        public UserAlreadyExistException(string? message) : base(message)
        {
        }

        public UserAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UserAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
