namespace Licenta.BLL.Utils.EmailSender.EmailSetup
{
    public class GenerateEmailToken
    {
        private static Random random = new Random();

        public static string GetEmailToken()
        {
            int length = 15;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }
    }
}
