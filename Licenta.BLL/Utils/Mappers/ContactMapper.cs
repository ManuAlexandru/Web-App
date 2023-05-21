using Licenta.BLL.Models.ContactModels;
using Licenta.Models.Models;

namespace Licenta.BLL.Utils.Mappers
{
    public static class ContactMapper
    {
        public static Contact ConvertToContact(this ContactViewModel A)
        {
            var B = new Contact()
            {
                Name = A.Name,
                Email = A.Email,
                Message = A.Message,
            };

            return B;
        }
    }
}
