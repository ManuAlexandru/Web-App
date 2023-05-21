using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class EmailNotConfirmedException : Exception
    {
        public EmailNotConfirmedException()
        {
        }

        public EmailNotConfirmedException(string message) : base(message)
        {
        }

        public EmailNotConfirmedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailNotConfirmedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
