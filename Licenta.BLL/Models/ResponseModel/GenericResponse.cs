using System.Net;

namespace Licenta.BLL.Models.ResponseModel
{
    public class GenericResponse
    {
        public string Message { get; set; }
        // public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsAuthSuccessful { get; set; }
        public string? Token { get; set; }
    }
}
