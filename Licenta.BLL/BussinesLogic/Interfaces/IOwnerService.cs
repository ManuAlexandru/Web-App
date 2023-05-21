using Licenta.BLL.Models;
using Licenta.Models.Models;
using Licenta.Models.Models.Helpers;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface IOwnerService
    {
        Task<Page> InsertPage(PageViewModel site);
        List<PhotoModel> GetPhotos(string id);
        void SavePhotos(PhotoViewModel photoModel, string id);
        Task DeletePhotos(StoredPhotoModel storedPhotoModel);
        public Task<Boolean> CheckIfPageExist(string id);
        Task<PageViewModel> GetPage(string id);
        Task UpdatePageInformation(PageViewModel page);
        Task<List<Page>> GetPages();
        Task<Page> GetPageById(string id);
        Task DeletePage(string id);
    }
}