using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Contexts;
using Licenta.Models.Models;

namespace Licenta.DAL.Stores
{
    public class UserStore : MongoDBStore<User>, IUserStore
    {
        public UserStore(Context context) : base(context) { }
    }
}

