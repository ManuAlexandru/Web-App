using Licenta.Models.Models.Helpers;
using Microsoft.AspNetCore.Http;

namespace Licenta.BLL.Utils.StorePhotoLogic
{
    public interface IPhotoService
    {
        public List<PhotoModel> RetrievePhotos(string id, string retrievePath, string UrlPath);

        public void Save(IFormFile[] formFiles, string id, string savePath);

        void SavePhoto(IFormFile formFile, string id, string savePath);

        public void DeletedFromServer(string id, string[] fileName, string retrievePath);

        public void DeletedImageFromServer(string id, string fileName, string retrievePath);

        List<PhotoModel> DeleteFromMongo(List<PhotoModel> photosFromMongo, List<PhotoModel> photosFromUser);
    }
}