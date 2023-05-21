using System.Text.Json.Serialization;

namespace Licenta.BLL.Utils.EmailSender.Template
{
    public class EmailTemplate
    {
        [JsonPropertyName("from")]
        public from From { get; set; } = new from();
        [JsonPropertyName("to")]
        public List<to> To { get; set; } = new List<to>();
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("html")]
        public string Html { get; set; }
    }
}
