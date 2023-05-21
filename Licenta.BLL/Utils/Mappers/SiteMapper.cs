using Licenta.BLL.Models;
using Licenta.Models.Models;

namespace Licenta.Utils.Mappers
{
    public static class SiteMapper
    {
        public static Page ConvertToPage(this PageViewModel A)
        {
            var B = new Page
            {
                UserId = A.UserId,
                GymName = A.GymName,
                Description = A.Description,
                City = A.City,
                Country = A.Country,
                Addres = A.Addres,
                Price = A.Price,
                PhoneNumber = A.PhoneNumber,
                TypeOfMoney = A.TypeOfMoney,
                IsCreditCardPaymentPossible = A.IsCreditCardPaymentPossible,
                TypeOfGym = A.TypeOfGym,
                HasSevenCard = A.HasSevenCard
            };

            return B;
        }
        public static PageViewModel ConvertToPageModel(this Page A)
        {
            var B = new PageViewModel
            {
                UserId = A.UserId,
                GymName = A.GymName,
                Description = A.Description,
                City = A.City,
                Country = A.Country,
                Addres = A.Addres,
                Price = A.Price,
                PhoneNumber = A.PhoneNumber,
                TypeOfMoney = A.TypeOfMoney,
                IsCreditCardPaymentPossible = A.IsCreditCardPaymentPossible,
                TypeOfGym = A.TypeOfGym,
                HasSevenCard = A.HasSevenCard
            };

            return B;
        }
    }
}
