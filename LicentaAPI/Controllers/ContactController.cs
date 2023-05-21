using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models.ContactModels;
using Microsoft.AspNetCore.Mvc;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveContact([FromBody] ContactViewModel contact)
        {
            var result = await _contactService.SaveMessage(contact);

            return Ok(result);
        }
    }
}
