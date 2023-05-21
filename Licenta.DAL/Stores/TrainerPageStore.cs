using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Contexts;
using Licenta.Models.Models;

namespace Licenta.DAL.Stores
{
    public class TrainerPageStore : MongoDBStore<TrainerPage>, ITrainerPageStore
    {
        public TrainerPageStore(Context context) : base(context)
        {
        }
    }
}
