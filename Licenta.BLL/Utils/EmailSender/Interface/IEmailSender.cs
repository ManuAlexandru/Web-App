namespace Licenta.BLL.Utils.EmailSender.Interface
{
    public interface IEmailSender
    {
        Task<HttpResponseMessage> SendWithMailerSend(string emailAddres, string token);
    }
}