using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class PhotosNotDeletedException : Exception
    {
        public PhotosNotDeletedException()
        {
        }

        public PhotosNotDeletedException(string message) : base(message)
        {
        }

        public PhotosNotDeletedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhotosNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
