using MongoDB.Driver;

namespace Licenta.DAL.Interfaces
{
    public interface IMongoDBStore<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> FindOne(FilterDefinition<T> filter);
        Task<T> Insert(T obj);
        Task<T> Update(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task Delete(FilterDefinition<T> filter);
    }
}