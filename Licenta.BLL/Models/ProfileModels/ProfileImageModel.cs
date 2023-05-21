using Microsoft.AspNetCore.Http;

namespace Licenta.BLL.Models.ProfileModels
{
    public class ProfileImageModel
    {
        public string ProfileImage { get; set; }

        public IFormFile Image { get; set; }
    }
}
