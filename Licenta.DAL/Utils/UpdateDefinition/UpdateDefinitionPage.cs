using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;
using MongoDB.Driver;

namespace Licenta.DAL.Utils.UpdateDefinition
{
    public static class UpdateDefinitionPage
    {
        public static UpdateDefinition<Page> UpdatePhotosPage(this List<PhotoModel> page)
        {
            var updateDefinition = Builders<Page>.Update.AddToSetEach(page => page.Photos, page);

            return updateDefinition;
        }
        public static UpdateDefinition<Page> UpdateByDeletePhotos(this Page page)
        {
            var updateDefinition = Builders<Page>.Update.Set(pageMongo => pageMongo.Photos, page.Photos);

            return updateDefinition;
        }
        public static UpdateDefinition<Page> UpdatePageInfo(this Page page)
        {
            var updateDefinition = Builders<Page>.Update.Set(pageMongo => pageMongo.GymName, page.GymName)
                                                        .Set(pageMongo => pageMongo.Description, page.Description)
                                                        .Set(pageMongo => pageMongo.Price, page.Price)
                                                        .Set(pageMongo => pageMongo.Country, page.Country)
                                                        .Set(pageMongo => pageMongo.City, page.City)
                                                        .Set(pageMongo => pageMongo.Addres, page.Addres)
                                                        .Set(pageMongo => pageMongo.HasSevenCard, page.HasSevenCard)
                                                        .Set(pageMongo => pageMongo.TypeOfGym, page.TypeOfGym)
                                                        .Set(pageMongo => pageMongo.IsCreditCardPaymentPossible, page.IsCreditCardPaymentPossible)
                                                        .Set(pageMongo => pageMongo.PhoneNumber, page.PhoneNumber)
                                                        .Set(pageMongo => pageMongo.TypeOfMoney, page.TypeOfMoney);

            return updateDefinition;
        }
    }
}
