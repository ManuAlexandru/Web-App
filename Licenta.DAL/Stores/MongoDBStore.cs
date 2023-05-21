using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Contexts;
using MongoDB.Driver;

namespace Licenta.DAL.Stores
{
    public abstract class MongoDBStore<T> : IMongoDBStore<T>
        where T : class
    {
        protected readonly Context context;

        public MongoDBStore(Context context)
        {
            this.context = context;
        }

        public async Task<List<T>> GetAll()
        {
            var users = await context.Collection<T>().FindAsync(_ => true);
            var resultUsers = users.ToList();//list of users          

            return resultUsers;
        }
        public async Task<T> Insert(T obj)
        {
            await context.Collection<T>().InsertOneAsync(obj);

            return obj;
        }
        public async Task<T> Update(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var user = await context.Collection<T>().FindOneAndUpdateAsync(
                filter, update);

            return user;
        }
        public async Task Delete(FilterDefinition<T> filter)
        {
            await context.Collection<T>().DeleteOneAsync(filter);
        }
        public async Task<T> FindOne(FilterDefinition<T> filter)
        {
            var user = await context.Collection<T>().FindAsync(filter);
            var result = user.FirstOrDefaultAsync()?.Result;

            return result;
        }
    }
}