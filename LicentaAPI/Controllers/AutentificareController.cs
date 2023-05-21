using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.CustomExceptions;
using Licenta.BLL.Models;
using Licenta.BLL.Models.ResponseModel;
using Licenta.BLL.Utils.EmailSender.Interface;
using Licenta.BLL.Utils.Token.Interface;
using Licenta.Models.Constant;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutentificareController : ControllerBase
    {
        private readonly IUserService _userAction;

        private readonly IJwtHandler _jwtHandler;

        private readonly IEmailSender _emailSender;

        public AutentificareController(IUserService userAction, IJwtHandler jwtHandler, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _userAction = userAction;
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                var insertedUser = await _userAction.Register(userModel);
                // await _emailSender.SendWithMailerSend(insertedUser.Email, insertedUser.Token);
                return Ok(new GenericResponse { Message = MessageConstants.UserLoggedIn, StatusCode = HttpStatusCode.OK });
            }
            catch (UserAlreadyExistException)//An email already exist in DB
            {
                return Ok(new GenericResponse { Message = MessageConstants.EmailAlreadyExist, StatusCode = HttpStatusCode.Forbidden });
            }
            catch (UserNotInsertedException)//For some reason the user could not be inserted
            {
                return Ok(new GenericResponse { Message = MessageConstants.SomethingWentWrong, StatusCode = HttpStatusCode.Forbidden });
            }
            catch//A generic catch if somethin' unexpected happens
            {
                return Ok(new GenericResponse { Message = MessageConstants.InternalServerError, StatusCode = HttpStatusCode.Forbidden });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            try
            {
                var loginUser = await _userAction.Login(userModel);

                return Ok(new GenericResponse { IsAuthSuccessful = true, Token = _jwtHandler.GenerateToken(loginUser) });
            }
            catch (UserNotFoundException)//The credentials are invalid
            {
                return Unauthorized(new GenericResponse { Message = MessageConstants.InvalidAuthentification });
            }
            catch (EmailNotConfirmedException)//The email is not confirmed
            {
                return Unauthorized(new GenericResponse { Message = MessageConstants.EmailNotConfirmed });
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> EmailConfirmation([FromBody] EmailConfirmationModel emailConfirmationModel)
        {
            try
            {
                await _userAction.ConfirmEmail(emailConfirmationModel.Email, emailConfirmationModel.Token);

                return Ok(new GenericResponse { Message = MessageConstants.EmailConfirmed, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Unauthorized(new GenericResponse { Message = MessageConstants.SomethingWentWrong, StatusCode = HttpStatusCode.Forbidden });
            }

        }
    }
}
