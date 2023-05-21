using Licenta.BLL.Models;
using Licenta.Models.Models;

namespace Licenta.BLL.Utils.Mappers
{
    public static class TrainerMapper
    {
        public static TrainerPage ConvertToTrainerPage(this TrainerPageViewModel trainerPageViewModel)
        {

            return new()
            {
                UserId = trainerPageViewModel.UserId,
                FirstName = trainerPageViewModel.FirstName,
                LastName = trainerPageViewModel.LastName,
                Description = trainerPageViewModel.Description,
                Gyms = trainerPageViewModel.Gyms,
                Photos = trainerPageViewModel.Photos,
                City = trainerPageViewModel.City,
                Country = trainerPageViewModel.Country,
                Address = trainerPageViewModel.Address,
                Programs = trainerPageViewModel.Programs,
            };
        }

        public static TrainerPageViewModel ConvertToTrainerPageViewModel(this TrainerPage trainerPage)
        {

            return new()
            {
                UserId = trainerPage.UserId,
                FirstName = trainerPage.FirstName,
                LastName = trainerPage.LastName,
                Description = trainerPage.Description,
                Gyms = trainerPage.Gyms,
                Photos = trainerPage.Photos,
                City = trainerPage.City,
                Country = trainerPage.Country,
                Address = trainerPage.Address,
                Programs = trainerPage.Programs,
            };
        }
    }
}
