using System.Text.Json.Serialization;

namespace Licenta.BLL.Utils.EmailSender.Template
{
    public class to
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
