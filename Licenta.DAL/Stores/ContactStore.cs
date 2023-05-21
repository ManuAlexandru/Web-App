using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Contexts;
using Licenta.Models.Models;

namespace Licenta.DAL.Stores
{
    public class ContactStore : MongoDBStore<Contact>, IContactStore
    {
        public ContactStore(Context context) : base(context)
        {
        }
    }
}
