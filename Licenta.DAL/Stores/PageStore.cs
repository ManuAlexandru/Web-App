using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Contexts;
using Licenta.Models.Models;

namespace Licenta.DAL.Stores
{
    public class PageStore : MongoDBStore<Page>, IPageStore
    {
        public PageStore(Context context) : base(context) { }
    }
}
