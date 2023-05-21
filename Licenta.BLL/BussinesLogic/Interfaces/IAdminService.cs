using Licenta.BLL.Models;
using Licenta.Models.Models;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface IAdminService
    {
        Task DeleteUser(string userId);
        Task<UserModel> FindUser(string userId);
        Task<List<UserModifyModel>> GetUsers();
        Task<User> ModifyUser(UserModifyModel userM);
    }
}