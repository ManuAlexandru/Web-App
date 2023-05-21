using Licenta.BLL.Utils.EmailSender.EmailSetup;
using Licenta.BLL.Utils.EmailSender.Interface;
using Licenta.BLL.Utils.EmailSender.Settings;
using Licenta.BLL.Utils.EmailSender.Template;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Licenta.BLL.Utils.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly string _token;
        private readonly EmailTemplate emailTemplate;
        public EmailSender(IOptions<EmailSettings> options)
        {
            _token = options.Value.Token;
        }
        public async Task<HttpResponseMessage> SendWithMailerSend(string emailAddres, string token)
        {
            var body = EmailConstructor.ContructEmail(emailAddres, token);
            var json = JsonSerializer.Serialize(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);

            var response = await client.PostAsync("https://api.mailersend.com/v1/email", data);

            return response;
        }
    }
}
