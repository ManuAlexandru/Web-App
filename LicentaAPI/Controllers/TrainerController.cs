using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models;
using Licenta.BLL.Models.ResponseModel;
using Licenta.Models.Constant;
using Licenta.Models.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Licenta.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,Owner")]
public class TrainerController : Controller
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<int> CreatePage(TrainerPageViewModel trainerPage)
    {
        await _trainerService.InsertPage(trainerPage);

        return 1;
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> ExistPage(string id)
    {
        var response = await _trainerService.CheckIfTrainerPageExist(id);
        if (response)
            return Ok(new GenericResponse { Message = MessageConstants.PageFound, StatusCode = HttpStatusCode.OK });

        return Ok(new GenericResponse { Message = MessageConstants.PageNotFound, StatusCode = HttpStatusCode.NotFound });
    }

    [HttpPut]
    [Route("[action]/{id}")]
    public IActionResult SendPhotos(string id, [FromForm] PhotoViewModel photoModel)
    {
        try
        {
            _trainerService.SavePhotos(photoModel, id);
        }
        catch
        {
            return Ok(new GenericResponse { Message = MessageConstants.PhotosNotAdded, StatusCode = HttpStatusCode.OK });
        }
        return Ok(new GenericResponse { Message = MessageConstants.PhotosAdded, StatusCode = HttpStatusCode.OK });
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<TrainerPageViewModel> GetPage(string id)
    {
        var pageModel = await _trainerService.GetPage(id);

        return pageModel;
    }

    [HttpPut]
    [Route("[action]/{id}")]
    public IActionResult EditPageInfo(string id, TrainerPageViewModel page)
    {
        try
        {
            _trainerService.UpdatePageInformation(page);
        }
        catch
        {
            return Ok(new GenericResponse { Message = MessageConstants.PageInfoNotModified, StatusCode = HttpStatusCode.InternalServerError });
        }

        return Ok(new GenericResponse { Message = MessageConstants.PageInfoModified, StatusCode = HttpStatusCode.OK });
    }

    [HttpPut]
    [Route("[action]")]
    public IActionResult DeletePhotos([FromBody] StoredPhotoModel storedPhotoModel)
    {
        try
        {
            _trainerService.DeletePhotos(storedPhotoModel);
        }
        catch
        {
            return Ok(new GenericResponse { Message = MessageConstants.PhotosNotDeleted, StatusCode = HttpStatusCode.InternalServerError });
        }
        return Ok(new GenericResponse { Message = MessageConstants.PhotosDeleted, StatusCode = HttpStatusCode.OK });
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public List<PhotoModel> GetPhotosRoutes(string id)
    {
        var result = _trainerService.GetPhotos(id);

        return result;
    }
}
