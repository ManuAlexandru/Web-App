using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models;
using Licenta.BLL.Utils.Mappers;
using Licenta.BLL.Utils.StorePhotoLogic;
using Licenta.BLL.Utils.StorePhotoLogic.Settings;
using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Filters;
using Licenta.DAL.Utils.UpdateDefinition;
using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;
using Microsoft.Extensions.Options;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerPageStore _trainerPageStore;
        private readonly IPhotoService _photoService;
        private readonly IOptions<PhotoRoutingSettings> _options;

        public TrainerService(ITrainerPageStore trainerPageStore, IPhotoService photoService, IOptions<PhotoRoutingSettings> options)
        {
            _trainerPageStore = trainerPageStore;
            _photoService = photoService;
            _options = options;
        }

        public async Task<List<TrainerPage>> GetPages()
        {
            return await _trainerPageStore.GetAll();
        }

        public async Task<TrainerPageViewModel> GetPageById(string id)
        {
            var page = await _trainerPageStore.FindOne(id.SearchTrainerPageById());
            if (page is null)
                throw new PageNotFoundException("We did not find the page, sorrrry!!!!");

            return page.ConvertToTrainerPageViewModel();
        }

        public async Task InsertPage(TrainerPageViewModel trainerPageViewModel)
        {

            var result = await _trainerPageStore.Insert(trainerPageViewModel.ConvertToTrainerPage());
            if (result is null)
            {
                throw new TrainerPageNotCreatedException("Something went wrong");
            }
        }

        public async Task<TrainerPageViewModel> GetPage(string id)
        {
            var page = await _trainerPageStore.FindOne(id.SearchTrainerPageByUserId());
            if (page is null)
                throw new PageNotFoundException("We did not find the page, sorrrry!!!!");

            return page.ConvertToTrainerPageViewModel();
        }

        public async Task<Boolean> CheckIfTrainerPageExist(string id)
        {
            var response = await _trainerPageStore.FindOne(id.SearchTrainerPageByUserId());

            if (response is null)
                return false;

            return true;
        }

        public void SavePhotos(PhotoViewModel photoModel, string id)
        {
            if (photoModel.File.Any(photoName => photoName.FileName.Split(".")[1] != "jpg"))

                throw new NotCorrectFormatException("Image/Images does not have the correct format");

            try
            {
                _photoService.Save(photoModel.File, id, _options.Value.SavePathTrainer);
                var photoRoutes = _photoService.RetrievePhotos(id, _options.Value.RetrievePathTrainer, _options.Value.URL);

                _trainerPageStore.Update(id.SearchTrainerPageByUserId(), photoRoutes.UpdatePhotosTrainer());
            }
            catch
            {
                throw new PhotosNotSavedException("Something went wrong while saving the images");
            }
        }

        public List<PhotoModel> GetPhotos(string id)
        {
            return _trainerPageStore.FindOne(id.SearchTrainerPageByUserId()).Result.Photos;//I should use async?
        }

        public async Task DeletePhotos(StoredPhotoModel storedPhotoModel)
        {
            try
            {
                var page = await _trainerPageStore.FindOne(storedPhotoModel.Id.SearchTrainerPageByUserId());
                if (page is null)
                    throw new PageNotFoundException("Page not found");

                _photoService.DeletedFromServer(storedPhotoModel.Id, storedPhotoModel.PhotoDetails.Select(photo => photo.FileName).ToArray(), _options.Value.RetrievePathTrainer);

                page.Photos = _photoService.DeleteFromMongo(page.Photos, storedPhotoModel.PhotoDetails);

                await _trainerPageStore.Update(storedPhotoModel.Id.SearchTrainerPageByUserId(), page.UpdateDeleteTrainerPhotos());
            }
            catch
            {
                throw new PhotosNotDeletedException("Something went wrong when deleting the images");
            }
        }

        public async Task UpdatePageInformation(TrainerPageViewModel trainerPage)
        {
            await _trainerPageStore.Update(trainerPage.UserId.SearchTrainerPageByUserId(), trainerPage.ConvertToTrainerPage().
                UpdateTrainerPageInformation());
        }
    }
}
