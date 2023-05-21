using Licenta.BLL.Models.GeoModels;

namespace Licenta.BLL.BussinesLogic.Interfaces
{
    public interface IGeoService
    {
        ICollection<CountryModel> GetCountry();
    }
}