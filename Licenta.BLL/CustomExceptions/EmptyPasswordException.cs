using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    internal class EmptyPasswordException : Exception
    {
        public EmptyPasswordException()
        {
        }

        public EmptyPasswordException(string message) : base(message)
        {
        }

        public EmptyPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
