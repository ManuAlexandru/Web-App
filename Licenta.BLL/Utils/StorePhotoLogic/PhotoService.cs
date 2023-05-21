using Licenta.BLL.CustomExceptions;
using Licenta.Models.Models.Helpers;
using Microsoft.AspNetCore.Http;

namespace Licenta.BLL.Utils.StorePhotoLogic
{
    public class PhotoService : IPhotoService
    {

        public List<PhotoModel> RetrievePhotos(string id, string retrievePath, string UrlPath)
        {
            //need to add a try/catch block
            string path = Path.Combine(retrievePath, id);
            string[] paths = Directory.GetFiles(path, "*jpg");
            //Not sure about this
            //I should put in another method where I would call Save and RetrievePhotos
            //////////////////////////////////////////////

            var listOfPhotos = new List<PhotoModel>();
            foreach (var route in paths)
            {
                var photoModelForMongo = new PhotoModel();
                photoModelForMongo.Route = Path.Combine(UrlPath, route);
                photoModelForMongo.FileName = Path.GetFileName(route);
                listOfPhotos.Add(photoModelForMongo);
            }
            //////////////////////////////////////////////

            return listOfPhotos;
        }

        public void SavePhoto(IFormFile formFile, string id, string savePath)
        {
            string path = Path.Combine(savePath, id);
            Directory.CreateDirectory(path);
            Stream stream;

            try
            {
                var relativepath = Path.Combine(path, Guid.NewGuid().ToString() + "." + formFile.FileName.Split(".")[1]);//TODO Not sure about this
                stream = new FileStream(relativepath, FileMode.Create);
                formFile.CopyTo(stream);
                stream.Close();

            }
            catch { throw new PhotosNotSavedException("Images not saved for some reason"); }
        }

        public void Save(IFormFile[] formFiles, string id, string savePath)
        {
            string path = Path.Combine(savePath, id);
            Directory.CreateDirectory(path);
            Stream stream;
            try
            {
                foreach (var photo in formFiles)
                {
                    var relativepath = Path.Combine(path, Guid.NewGuid().ToString() + "." + photo.FileName.Split(".")[1]);//TODO Not sure about this
                    stream = new FileStream(relativepath, FileMode.Create);
                    photo.CopyTo(stream);
                    stream.Close();
                }
            }
            catch { throw new PhotosNotSavedException("Images not saved for some reason"); }
        }

        public void DeletedFromServer(string id, string[] fileName, string retrievePath)
        {
            foreach (var file in fileName)
            {
                File.Delete(Path.Combine(retrievePath + id + "/" + file));
                Console.WriteLine(retrievePath + id + file);
            }
        }

        public void DeletedImageFromServer(string id, string fileName, string retrievePath)
        {
            File.Delete(Path.Combine(retrievePath + id + "/" + fileName));
            Console.WriteLine(retrievePath + id + fileName);
        }

        public List<PhotoModel> DeleteFromMongo(List<PhotoModel> photosFromMongo, List<PhotoModel> photosFromUser)
        {
            int length = photosFromMongo.Count;
            for (int i = 0; i < length; i++)
            {
                if (photosFromUser.Any(photo => photo.FileName == photosFromMongo[i].FileName))
                {
                    photosFromMongo.RemoveAt(i);
                    length = photosFromMongo.Count;
                    i--;
                }
            }

            return photosFromMongo;
        }

    }
}
