using Licenta.BLL.Models;
using Licenta.BLL.Models.ProfileModels;
using Licenta.Models.Models;

namespace Licenta.BLL.Utils.Mappers
{
    public static class UserMapper
    {
        public static UserModel ParseToUserVM(this User B)
        {
            var A = new UserModel
            {
                Id = B.Id,
                Email = B.Email,
                FirstName = B.FirstName,
                LastName = B.LastName,
                Role = B.Role
            };

            return A;
        }
        public static UserModifyModel ParseToUserModifyModel(this User B)
        {
            var A = new UserModifyModel
            {
                Id = B.Id,
                Email = B.Email,
                FirstName = B.FirstName,
                LastName = B.LastName,
                Role = B.Role
            };

            return A;
        }

        public static User ParseToUserFromUserModifyModel(this UserModifyModel B)
        {
            var A = new User
            {
                Id = B.Id,
                Email = B.Email,
                FirstName = B.FirstName,
                LastName = B.LastName,
                Role = B.Role
            };

            return A;
        }
        public static User ParseToUserModel(this UserModel B)
        {
            var A = new User
            {
                Id = B.Id,
                Email = B.Email,
                FirstName = B.FirstName,
                LastName = B.LastName,
                Role = B.Role
            };

            return A;
        }

        public static UserEditModel ParseToEditUserModel(this User B)
        {
            var A = new UserEditModel
            {
                Id = B.Id,
                Email = B.Email,
                FirstName = B.FirstName,
                LastName = B.LastName,
                Role = B.Role
            };

            return A;
        }

        public static User SentDataToCreateUser(this UserModel B)
        {
            var A = new User
            {
                Email = B.Email,
                Password = B.Password,
                FirstName = B.FirstName,
                LastName = B.LastName
            };

            return A;
        }

        public static User SentDataToConnectUser(this UserModel B)
        {
            var A = new User
            {
                Email = B.Email,
                Password = B.Password
            };

            return A;
        }

        public static User SendDataToUpdateUserName(this ProfileNameModel B)
        {
            var A = new User
            {
                FirstName = B.FirstName,
                LastName = B.LastName,
            };

            return A;
        }
        public static User SendDataToUpdatePassword(this ProfilePasswordModel B)
        {
            var A = new User
            {
                Password = B.newPassword,
            };

            return A;
        }

        public static ProfileUserModel ConvertToProfileUser(this User B)
        {
            var A = new ProfileUserModel
            {
                FirstName = B.FirstName,
                LastName = B.LastName,
            };

            return A;
        }
    }
}
