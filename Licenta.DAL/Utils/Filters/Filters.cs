using Licenta.Models.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Licenta.DAL.Utils.Filters
{
    public static class Filters
    {
        public static FilterDefinition<User> SearchById(this string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));

            return filter;
        }
        public static FilterDefinition<User> SearchByEmail(this string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);

            return filter;
        }
        public static FilterDefinition<Page> SearchPageByUserId(this string id)
        {
            var filter = Builders<Page>.Filter.Eq("UserId", id);

            return filter;
        }

        public static FilterDefinition<Page> SearchPageById(this string id)
        {
            var filter = Builders<Page>.Filter.Eq("_id", ObjectId.Parse(id));

            return filter;
        }

        public static FilterDefinition<TrainerPage> SearchTrainerPageByUserId(this string id)
        {
            var filter = Builders<TrainerPage>.Filter.Eq("UserId", id);

            return filter;
        }

        public static FilterDefinition<TrainerPage> SearchTrainerPageById(this string id)
        {
            var filter = Builders<TrainerPage>.Filter.Eq("_id", ObjectId.Parse(id));

            return filter;
        }
    }
}
