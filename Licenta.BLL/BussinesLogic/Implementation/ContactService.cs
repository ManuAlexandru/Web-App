using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models.ContactModels;
using Licenta.BLL.Utils.Mappers;
using Licenta.DAL.Interfaces;
using Licenta.Models.Models;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactStore _contactStore;
        public ContactService(IContactStore contactStore)
        {
            _contactStore = contactStore;
        }

        public async Task<Contact> SaveMessage(ContactViewModel contact)
        {
            var result = await _contactStore.Insert(contact.ConvertToContact());

            return result;
        }
    }
}
