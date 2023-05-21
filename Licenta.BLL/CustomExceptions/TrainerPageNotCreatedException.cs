using System.Runtime.Serialization;

namespace Licenta.BLL.CustomExceptions
{
    public class TrainerPageNotCreatedException : Exception
    {
        public TrainerPageNotCreatedException()
        {
        }

        public TrainerPageNotCreatedException(string message) : base(message)
        {
        }

        public TrainerPageNotCreatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TrainerPageNotCreatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
