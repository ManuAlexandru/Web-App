using Microsoft.AspNetCore.Http;

namespace Licenta.BLL.Models
{
    public class PhotoViewModel
    {
        public IFormFile[] File { get; set; }
    }
}
