using Licenta.Models.Models.Helpers;
using MongoDB.Bson.Serialization.Attributes;

namespace Licenta.Models.Models
{
    public sealed class Page
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string IdPage { get; set; }
        public string UserId { get; set; }
        public string GymName { get; set; }
        public string Description { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
        public string Country { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string Price { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> Trainers { get; set; } = new List<string>();
        public string TypeOfMoney { get; set; } = "RON";
        public bool IsCreditCardPaymentPossible { get; set; }
        public string TypeOfGym { get; set; }
        public bool HasSevenCard { get; set; }
    }
}
