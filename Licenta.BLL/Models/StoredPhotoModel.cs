using Licenta.Models.Models.Helpers;

namespace Licenta.BLL.Models
{
    public class StoredPhotoModel
    {
        public string Id { get; set; }
        public List<PhotoModel> PhotoDetails { get; set; }
    }
}
