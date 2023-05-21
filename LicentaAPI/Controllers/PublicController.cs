using Licenta.BLL.BussinesLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly IOwnerService _ownerService;

        public PublicController(ITrainerService trainerService, IOwnerService ownerService)
        {
            _trainerService = trainerService;
            _ownerService = ownerService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllGyms()
        {
            var result = await _ownerService.GetPages();

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetGym([FromRoute] string id)
        {
            var result = await _ownerService.GetPageById(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTrainers()
        {
            var result = await _trainerService.GetPages();

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetTrainer([FromRoute] string id)
        {
            var result = await _trainerService.GetPageById(id);

            return Ok(result);
        }

    }
}
