using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;
using MongoDB.Driver;

namespace Licenta.DAL.Utils.UpdateDefinition
{
    public static class UpdateDefinitionTrainerPage
    {
        public static UpdateDefinition<TrainerPage> UpdatePhotosTrainer(this List<PhotoModel> photoList)
        {
            var updateDefinition = Builders<TrainerPage>.Update.AddToSetEach(trainerPage => trainerPage.Photos, photoList);

            return updateDefinition;
        }

        public static UpdateDefinition<TrainerPage> UpdateDeleteTrainerPhotos(this TrainerPage trainerPage)
        {
            var updateDefinition = Builders<TrainerPage>.Update.Set(trinerPageMongo => trinerPageMongo.Photos, trainerPage.Photos);

            return updateDefinition;
        }

        public static UpdateDefinition<TrainerPage> UpdateTrainerPageInformation(this TrainerPage trainerPage)
        {
            var updateDefinition = Builders<TrainerPage>.Update.Set(trinerPageMongo => trinerPageMongo.FirstName, trainerPage.FirstName)
                                                        .Set(trinerPageMongo => trinerPageMongo.LastName, trainerPage.LastName)
                                                        .Set(trinerPageMongo => trinerPageMongo.Description, trainerPage.Description)
                                                        .Set(trinerPageMongo => trinerPageMongo.Gyms, trainerPage.Gyms)
                                                        .Set(trinerPageMongo => trinerPageMongo.Programs, trainerPage.Programs);

            return updateDefinition;
        }
    }
}
