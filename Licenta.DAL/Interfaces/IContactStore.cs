using Licenta.Models.Models;

namespace Licenta.DAL.Interfaces
{
    public interface IContactStore : IMongoDBStore<Contact>
    {
    }
}
