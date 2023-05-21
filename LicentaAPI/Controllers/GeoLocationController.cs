using Licenta.BLL.BussinesLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin,User,Trainer,Owner")]
    public class GeoLocationController : Controller
    {
        private readonly IGeoService _geoService;
        public GeoLocationController(IGeoService geoService)
        {
            _geoService = geoService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetCountries()
        {
            var result = _geoService.GetCountry();

            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetCity()
        {
            return Ok();
        }

    }
}
