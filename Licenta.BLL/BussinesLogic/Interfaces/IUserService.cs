using Licenta.BLL.Models;
using Licenta.BLL.Models.ProfileModels;
using Licenta.Models.Models;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(UserModel userM);
        Task<User> Register(UserModel userM);
        Task<User> ConfirmEmail(string email, string token);
        public Task UpdatePassword(string id, ProfilePasswordModel passwordModel);
        public Task<ProfileUserModel> GetUser(string id);
        public Task UpdateName(string id, ProfileNameModel profileNameModel);
    }
}