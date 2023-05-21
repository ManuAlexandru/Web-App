using System.Text.Json.Serialization;

namespace Licenta.BLL.Utils.EmailSender.Template
{

    public class from
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
