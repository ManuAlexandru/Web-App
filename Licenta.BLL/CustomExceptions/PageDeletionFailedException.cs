using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class PageDeletionFailedException : Exception
    {
        public PageDeletionFailedException()
        {
        }

        public PageDeletionFailedException(string message) : base(message)
        {
        }

        public PageDeletionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PageDeletionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
