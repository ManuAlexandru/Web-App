using Licenta.Models.Models.Helpers;

namespace Licenta.BLL.Models
{
    public class TrainerPageViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public List<string> Gyms { get; set; } = new List<string>();
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
        public List<TrainingProgramModel> Programs{ get; set; }
    }
}
