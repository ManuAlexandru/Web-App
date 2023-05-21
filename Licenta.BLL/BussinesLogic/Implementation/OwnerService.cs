using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models;
using Licenta.BLL.Utils.StorePhotoLogic;
using Licenta.BLL.Utils.StorePhotoLogic.Settings;
using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Filters;
using Licenta.DAL.Utils.UpdateDefinition;
using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;
using Licenta.Utils.Mappers;
using Microsoft.Extensions.Options;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IPageStore _pageStore;
        private readonly IPhotoService _photoService;
        private readonly IOptions<PhotoRoutingSettings> _options;

        public OwnerService(IPageStore pageStore, IPhotoService photoService, IOptions<PhotoRoutingSettings> options)
        {
            _pageStore = pageStore;
            _photoService = photoService;
            _options = options;
        }

        public async Task<List<Page>> GetPages()
        {
            return await _pageStore.GetAll();
        }

        public async Task<Page> GetPageById(string id)
        {
            var page = await _pageStore.FindOne(id.SearchPageById());
            if (page is null)
                throw new PageNotFoundException("We did not find the page, sorrrry!!!!");

            return page;
        }

        public async Task<PageViewModel> GetPage(string id)
        {
            var page = await _pageStore.FindOne(id.SearchPageByUserId());
            if (page is null)
                throw new PageNotFoundException("We did not find the page, sorrrry!!!!");

            return page.ConvertToPageModel();
        }

        public async Task DeletePage(string idUser)
        {
            var page = await _pageStore.FindOne(idUser.SearchPageByUserId());
            try
            {
                _photoService.DeletedFromServer(page.UserId,
                    page.Photos.Select(elem => elem.FileName).ToArray(),
                    _options.Value.RetrievePathOwner);
            }
            catch
            {
                throw new PageDeletionFailedException("Failed to delete photos!");
            }
            await _pageStore.Delete(page.IdPage.SearchPageById());
        }

        public async Task<Boolean> CheckIfPageExist(string id)
        {
            var response = await _pageStore.FindOne(id.SearchPageByUserId());

            if (response is null)
                return false;

            return true;
        }

        public async Task<Page> InsertPage(PageViewModel site)
        {
            var response = await _pageStore.Insert(site.ConvertToPage());

            return response;
        }

        public void SavePhotos(PhotoViewModel photoModel, string id)
        {
            //1: I take every File from the Array 
            //2: Check if any name of the file expected has .jpg extension
            //3:I use split method for that to separate the extension, which i know is the second
            //  That's why I take the second element from the string.
            if (photoModel.File.Any(photoName => photoName.FileName.Split(".")[1] != "jpg"))

                throw new NotCorrectFormatException("Image/Images does not have the correct format");

            try
            {
                _photoService.Save(photoModel.File, id, _options.Value.SavePathOwner);

                var photoRoutes = _photoService.RetrievePhotos(id, _options.Value.RetrievePathOwner, _options.Value.URL);

                _pageStore.Update(id.SearchPageByUserId(), photoRoutes.UpdatePhotosPage());
            }
            catch
            {
                throw new PhotosNotSavedException("Something went wrong while saving the images");
            }
        }

        public List<PhotoModel> GetPhotos(string id)
        {
            return _pageStore.FindOne(id.SearchPageByUserId()).Result.Photos;//I should use async?
        }

        public async Task DeletePhotos(StoredPhotoModel storedPhotoModel)
        {
            try
            {
                var page = await _pageStore.FindOne(storedPhotoModel.Id.SearchPageByUserId());
                if (page is null)
                    throw new PageNotFoundException("Page not found");

                _photoService.DeletedFromServer(storedPhotoModel.Id, storedPhotoModel.PhotoDetails.Select(photo => photo.FileName).ToArray(), _options.Value.RetrievePathOwner);

                page.Photos = _photoService.DeleteFromMongo(page.Photos, storedPhotoModel.PhotoDetails);

                await _pageStore.Update(storedPhotoModel.Id.SearchPageByUserId(), page.UpdateByDeletePhotos());
            }
            catch
            {
                throw new PhotosNotDeletedException("Something went wrong when deleting the images");
            }
        }

        public async Task UpdatePageInformation(PageViewModel page)
        {
            await _pageStore.Update(page.UserId.SearchPageByUserId(), page.ConvertToPage()
                                                                          .UpdatePageInfo());
        }
    }
}
