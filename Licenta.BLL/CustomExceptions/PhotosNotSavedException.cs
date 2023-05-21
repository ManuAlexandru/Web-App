using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class PhotosNotSavedException : Exception
    {
        public PhotosNotSavedException()
        {
        }

        public PhotosNotSavedException(string message) : base(message)
        {
        }

        public PhotosNotSavedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhotosNotSavedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
