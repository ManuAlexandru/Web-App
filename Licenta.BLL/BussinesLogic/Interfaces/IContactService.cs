using Licenta.BLL.Models.ContactModels;
using Licenta.Models.Models;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface IContactService
    {
        Task<Contact> SaveMessage(ContactViewModel contact);
    }
}