using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models;
using Licenta.BLL.Models.ProfileModels;
using Licenta.BLL.Utils.EmailSender.EmailSetup;
using Licenta.BLL.Utils.Mappers;
using Licenta.BLL.Utils.StorePhotoLogic;
using Licenta.BLL.Utils.StorePhotoLogic.Settings;
using Licenta.DAL.Interfaces;
using Licenta.DAL.Utils.Filters;
using Licenta.DAL.Utils.UpdateDefinition;
using Licenta.DAL.Utils.UsersFunctions;
using Licenta.Models.Models;
using Microsoft.Extensions.Options;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserStore _userStore;
        private readonly IPhotoService _photoService;
        private readonly IOptions<PhotoRoutingSettings> _options;

        public UserService(IUserStore userStore, IPhotoService photoService, IOptions<PhotoRoutingSettings> options)
        {
            _userStore = userStore;
            _photoService = photoService;
            _options = options;
        }

        public async Task<ProfileUserModel> GetUser(string id)
        {
            var filterId = id.SearchById();
            var user = await _userStore.FindOne(filterId);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            return user.ConvertToProfileUser();
        }

        public async Task<User> Register(UserModel userM)
        {
            var filterEmail = userM.Email.SearchByEmail();
            var existUser = await _userStore.FindOne(filterEmail);

            if (existUser is not null)
            {
                throw new UserAlreadyExistException("Email taken!");
            }
            //hash the password
            userM.Password = userM.Password.HashPassword();
            //mapping the user
            var user = userM.SentDataToCreateUser();
            //adding the EmailToken
            user.Token = GenerateEmailToken.GetEmailToken();
            //insert the user
            var response = await _userStore.Insert(user);
            if (response is null)
            {
                throw new UserNotInsertedException("User not Inserted");
            }

            return response;
        }
        public async Task<User> Login(UserModel userM)
        {
            var filterEmail = userM.Email.SearchByEmail();
            var user = await _userStore.FindOne(filterEmail);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            var hashedLogPass = userM.Password.HashPassword();

            if (hashedLogPass != user.Password)
            {
                throw new UserNotFoundException("User not Found");
            }
            if (user.EmailConfirmed is false)
            {
                throw new EmailNotConfirmedException("Email not confirmed");
            }

            return user;
        }

        public async Task<User> ConfirmEmail(string email, string token)
        {
            var filterEmail = email.SearchByEmail();
            var user = await _userStore.FindOne(filterEmail);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            if (user.Token != token)
            {
                throw new UserNotFoundException("User not Found");
            }

            user.EmailConfirmed = true;
            var userUpdated = await _userStore.Update(filterEmail, user.UpdateEmailConfirmed());

            if (userUpdated is null)
            {
                throw new UpdateFailedException("Updated failed");
            }

            return userUpdated;
        }

        public async Task UpdateName(string id, ProfileNameModel profileNameModel)
        {
            var filterId = id.SearchById();
            var user = await _userStore.FindOne(filterId);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            var userUpdated = await _userStore.Update(filterId, profileNameModel.SendDataToUpdateUserName().UserNameUpdate());

            if (userUpdated is null)
            {
                throw new UpdateFailedException("Updated failed");
            }
        }

        public async Task UpdatePassword(string id, ProfilePasswordModel passwordModel)
        {
            var filterId = id.SearchById();
            var user = await _userStore.FindOne(filterId);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            if (passwordModel.newPassword is null || passwordModel.currentPassword is null)
            {
                throw new EmptyPasswordException("Password is mandatory");
            }

            var hashedPass = passwordModel.currentPassword.HashPassword();

            if (hashedPass != user.Password)
            {
                throw new NotSamePasswordException("Not the same Password");
            }

            user.Password = passwordModel.newPassword.HashPassword();

            var userUpdated = await _userStore.Update(filterId, user.PasswordUpdate());

            if (userUpdated is null)
            {
                throw new UpdateFailedException("Updated failed");
            }
        }
        //TODO to be revised for photo logic
        public async Task UpdateProfileImage(string id, ProfileImageModel profileImageModel)
        {
            var filterId = id.SearchById();
            var user = await _userStore.FindOne(filterId);

            if (user is null)
            {
                throw new UserNotFoundException("User not Found!");
            }

            user.ProfileImage = profileImageModel.ProfileImage;

            if (profileImageModel.Image is null)
            {
                return;
            }


            _photoService.DeletedImageFromServer(id, user.ProfileImage, _options.Value.SaveUserProfileImage);

            _photoService.SavePhoto(profileImageModel.Image, user.Id, _options.Value.SaveUserProfileImage);

            var result = _photoService.RetrievePhotos(id, _options.Value.RetrieveUserProfileImage, _options.Value.URL);



            //var userUpdated = await _userStore.Update(filterId, );

            //if (userUpdated is null)
            //{
            //    throw new UpdateFailedException("Updated failed");
            //}
        }
    }
}
