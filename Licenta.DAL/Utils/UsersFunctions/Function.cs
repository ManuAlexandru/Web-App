using System.Security.Cryptography;
using System.Text;

namespace Licenta.DAL.Utils.UsersFunctions
{
    public static class Function
    {
        public static string HashPassword(this string password)
        {
            var sha = SHA256.Create();
            var asBytePass = Encoding.Default.GetBytes(password);
            var hashedPass = sha.ComputeHash(asBytePass);

            return Convert.ToBase64String(hashedPass);
        }
    }
}
