using Licenta.Models.Models.Helpers;
using MongoDB.Bson.Serialization.Attributes;

namespace Licenta.Models.Models
{
    public class TrainerPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string IdTrainerPage { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string TypeOfMoney { get; set; } = "RON";
        public string Address { get; set; }
        public List<string> Gyms { get; set; } = new List<string>();
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
        public List<TrainingProgramModel> Programs { get; set; }
    }
}
