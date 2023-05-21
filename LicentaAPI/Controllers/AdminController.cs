using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models;
using Licenta.BLL.Models.ResponseModel;
using Licenta.Models.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminAction)
        {
            _adminService = adminAction;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<UserModifyModel>> Users()
        {
            var listOfUsers = await _adminService.GetUsers();

            return listOfUsers;
        }

        [HttpGet("{userId}")]

        public async Task<UserModel> Edit(string userId)
        {
            var user = await _adminService.FindUser(userId);

            return user;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Modify(UserModifyModel userM)
        {

            try
            {
                await _adminService.ModifyUser(userM);

                return Ok(new GenericResponse { Message = MessageConstants.UserModified, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.UserNotModified, StatusCode = HttpStatusCode.InternalServerError });
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                await _adminService.DeleteUser(userId);

                return Ok(new GenericResponse { Message = MessageConstants.UserRemoved, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.UserNotRemoved, StatusCode = HttpStatusCode.InternalServerError });
            }
        }
    }
}
