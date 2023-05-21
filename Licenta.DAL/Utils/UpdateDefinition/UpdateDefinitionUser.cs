using Licenta.Models.Models;
using MongoDB.Driver;

namespace Licenta.DAL.Utils.UpdateDefinition
{
    public static class UpdateDefinitionUser
    {
        public static UpdateDefinition<User> UserUpdate(this User userModel)
        {
            var UpdateDefinition = Builders<User>.Update.Set(user => user.FirstName, userModel.FirstName)
                                                                   .Set(user => user.LastName, userModel.LastName)
                                                                   .Set(user => user.Email, userModel.Email)
                                                                   .Set(user => user.Role, userModel.Role);

            return UpdateDefinition;
        }

        public static UpdateDefinition<User> UserNameUpdate(this User userModel)
        {
            var UpdateDefinition = Builders<User>.Update.Set(user => user.FirstName, userModel.FirstName)
                                                                   .Set(user => user.LastName, userModel.LastName);

            return UpdateDefinition;
        }

        public static UpdateDefinition<User> PasswordUpdate(this User userModel)
        {
            var UpdateDefinition = Builders<User>.Update.Set(user => user.Password, userModel.Password);

            return UpdateDefinition;
        }

        public static UpdateDefinition<User> ProfileIamgedUpdate(this User userModel)
        {
            var UpdateDefinition = Builders<User>.Update.Set(user => user.ProfileImage, userModel.ProfileImage);

            return UpdateDefinition;
        }

        public static UpdateDefinition<User> UpdateEmailConfirmed(this User userModel)
        {
            var UpdateDefinition = Builders<User>.Update.Set(user => user.EmailConfirmed, userModel.EmailConfirmed);

            return UpdateDefinition;
        }
    }
}
