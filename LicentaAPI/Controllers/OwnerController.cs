using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models;
using Licenta.BLL.Models.ResponseModel;
using Licenta.Models.Constant;
using Licenta.Models.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LicentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,OwnerOfGym")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerAction;

        public OwnerController(IOwnerService action)
        {
            _ownerAction = action;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePage(PageViewModel site)
        {
            try
            {
                await _ownerAction.InsertPage(site);

                return Ok(new GenericResponse { Message = MessageConstants.PageCreated, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PageCreationFailed, StatusCode = HttpStatusCode.NotFound });
            }

        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeletePage([FromRoute] string id)
        {
            try
            {
                await _ownerAction.DeletePage(id);

                return Ok(new GenericResponse { Message = MessageConstants.PageDeletedSuccesfully, StatusCode = HttpStatusCode.OK });
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PageDeletionFailed, StatusCode = HttpStatusCode.NotFound });
            }

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ExistPage(string id)
        {
            var response = await _ownerAction.CheckIfPageExist(id);
            if (response)
                return Ok(new GenericResponse { Message = MessageConstants.PageFound, StatusCode = HttpStatusCode.OK });

            return Ok(new GenericResponse { Message = MessageConstants.PageNotFound, StatusCode = HttpStatusCode.NotFound });
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<PageViewModel> GetPage(string id)
        {
            var pageModel = await _ownerAction.GetPage(id);

            return pageModel;
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult SendPhotos(string id, [FromForm] PhotoViewModel photoModel)
        {
            try
            {
                _ownerAction.SavePhotos(photoModel, id);
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PhotosNotAdded, StatusCode = HttpStatusCode.OK });
            }
            return Ok(new GenericResponse { Message = MessageConstants.PhotosAdded, StatusCode = HttpStatusCode.OK });
        }
        //[HttpGet]
        //[Route("[action]/{id}")]
        //public IActionResult Getphoto(string id)
        //{
        //    List<Result> bytePhotos = new List<Result>();

        //    var result = _ownerAction.GetPhotos(id);

        //    foreach (var photo in result)
        //    {
        //        var result1 = new Result();
        //       // result1.bytes = System.IO.File.ReadAllBytes(photo);
        //        bytePhotos.Add(result1);
        //    }
        //    var json = JsonSerializer.Serialize(bytePhotos);
        //    var data = new StringContent(json, Encoding.UTF8, "image/jpeg");
        //    return Ok(bytePhotos);
        //}

        //public class Result
        //{
        //    public byte[] bytes { get; set; }
        //    public string ContentType { get; set; } = "image/jpeg";
        //}
        [HttpGet]
        [Route("[action]/{id}")]
        public List<PhotoModel> GetPhotosRoutes(string id)
        {
            var result = _ownerAction.GetPhotos(id);

            return result;
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult DeletePhotos([FromBody] StoredPhotoModel storedPhotoModel)
        {
            try
            {
                _ownerAction.DeletePhotos(storedPhotoModel);
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PhotosNotDeleted, StatusCode = HttpStatusCode.InternalServerError });
            }
            return Ok(new GenericResponse { Message = MessageConstants.PhotosDeleted, StatusCode = HttpStatusCode.OK });
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult EditPageInfo(string id, PageViewModel page)
        {//Not sure if i need an email here
            try
            {
                _ownerAction.UpdatePageInformation(page);
            }
            catch
            {
                return Ok(new GenericResponse { Message = MessageConstants.PageInfoNotModified, StatusCode = HttpStatusCode.InternalServerError });
            }

            return Ok(new GenericResponse { Message = MessageConstants.PageInfoModified, StatusCode = HttpStatusCode.OK });
        }
    }
}
