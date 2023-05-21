using Licenta.DAL.Utils.ConnectionSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Licenta.DAL.Utils.Contexts
{
    public class Context
    {
        private readonly IMongoDatabase _db;
        public Context(IOptions<ContextSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<T> Collection<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name);
        }
    }
}
