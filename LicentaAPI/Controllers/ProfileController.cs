using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models.ProfileModels;
using Licenta.BLL.Models.ResponseModel;
using Licenta.Models.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,Trainer,OwnerOfGym")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        public ProfileController(IUserService userAction, IAdminService adminService)
        {
            _userService = userAction;
            _adminService = adminService;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "Id").Value;

            var result = await _userService.GetUser(userId);

            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateImage()
        {
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateName([FromBody] ProfileNameModel profileNameModel)
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "Id").Value;

                await _userService.UpdateName(userId, profileNameModel);

                return Ok(new GenericResponse { Message = MessageConstants.NameModified, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.NameNotModified, StatusCode = HttpStatusCode.BadRequest });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] ProfilePasswordModel profilePasswordModel)
        {
            try
            {
                string userId = User.Claims.First(c => c.Type == "Id").Value;

                await _userService.UpdatePassword(userId, profilePasswordModel);

                return Ok(new GenericResponse { Message = MessageConstants.PasswordChanged, StatusCode = HttpStatusCode.OK });
            }
            catch (NotSamePasswordException)
            {
                return Ok(new GenericResponse { Message = MessageConstants.NotSamePassword, StatusCode = HttpStatusCode.BadRequest });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PasswordNotChanged, StatusCode = HttpStatusCode.BadRequest });
            }
        }
    }
}
