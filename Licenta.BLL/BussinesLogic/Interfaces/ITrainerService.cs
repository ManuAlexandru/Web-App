using Licenta.BLL.Models;
using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface ITrainerService
    {
        public Task InsertPage(TrainerPageViewModel trainerPageViewModel);

        public Task<Boolean> CheckIfTrainerPageExist(string id);
        public void SavePhotos(PhotoViewModel photoModel, string id);
        public List<PhotoModel> GetPhotos(string id);
        public Task<TrainerPageViewModel> GetPage(string id);
        public Task UpdatePageInformation(TrainerPageViewModel trainerPage);
        public Task DeletePhotos(StoredPhotoModel storedPhotoModel);
        Task<List<TrainerPage>> GetPages();
        Task<TrainerPageViewModel> GetPageById(string id);
    }
}