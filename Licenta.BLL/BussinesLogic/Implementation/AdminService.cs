using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models;
using Licenta.BLL.Utils.Mappers;
using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Filters;
using Licenta.DAL.Utils.UpdateDefinition;
using Licenta.Models.Models;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUserStore _userStore;

        public AdminService(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<List<UserModifyModel>> GetUsers()
        {
            var allUsers = await _userStore.GetAll();

            var listOfUsers = new List<UserModifyModel>();
            foreach (var user in allUsers)
            {
                listOfUsers.Add(user.ParseToUserModifyModel());
            }

            return listOfUsers;
        }

        public async Task<UserModel> FindUser(string userId)
        {
            var userMongo = await _userStore.FindOne(userId.SearchById());

            return userMongo.ParseToUserVM();
        }

        public async Task DeleteUser(string userId)
        {
            await _userStore.Delete(userId.SearchById());
        }

        public async Task<User> ModifyUser(UserModifyModel userM)
        {
            var userUpdated = await _userStore.Update(userM.Id.SearchById(), userM.ParseToUserFromUserModifyModel().UserUpdate());
            if (userUpdated is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return userUpdated;
        }
    }
}
