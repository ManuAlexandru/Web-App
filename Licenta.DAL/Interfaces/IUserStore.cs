using Licenta.Models.Models;

namespace Licenta.DAL.Interfaces
{
    public interface IUserStore : IMongoDBStore<User>
    {
    }
}
