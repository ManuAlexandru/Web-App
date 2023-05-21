using Licenta.Models.Models;

namespace Licenta.BLL.Utils.Token.Interface
{
    public interface IJwtHandler
    {
        public string GenerateToken(User user);
    }
}