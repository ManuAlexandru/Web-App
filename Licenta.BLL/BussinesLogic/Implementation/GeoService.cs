using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Models.GeoModels;
using System.Text.Json;

namespace Licenta.BLL.BussinesLogic.Implementation
{
    public class GeoService : IGeoService
    {
        public GeoService() { }


        public ICollection<CountryModel> GetCountry()
        {
            string jsonData = File.ReadAllText("Data/Countries.json");

            List<CountryModel> countries = JsonSerializer.Deserialize<List<CountryModel>>(jsonData);

            return countries;
        }
    }
}
