using Licenta.BLL.Utils.EmailSender.Template;

namespace Licenta.BLL.Utils.EmailSender.EmailSetup
{
    public class EmailConstructor
    {
        private static readonly from _from;

        public static EmailTemplate ContructEmail(string email, string token)
        {

            var body = new EmailTemplate();
            var to = new to();


            body.Subject = "Email Confirmation";
            string link = $"\"http://localhost:4200/emailConfirmation?email={email}&token={token}\"";
            body.Text = "Nothig specific";
            body.Html = $"<p>Please confirm your email <a href={link}>Click here to confirm!</a></p>";
            to.Email = email;
            to.Name = email;
            body.To.Add(to);

            return body;
        }
    }
}
