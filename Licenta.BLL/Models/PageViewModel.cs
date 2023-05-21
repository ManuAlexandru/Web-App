namespace Licenta.BLL.Models
{
    public sealed class PageViewModel
    {
        public string UserId { get; set; }
        public string GymName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string Price { get; set; }
        public int PhoneNumber { get; set; }
        public string TypeOfMoney { get; set; }
        public bool IsCreditCardPaymentPossible { get; set; } = false;
        public string TypeOfGym { get; set; } 
        public bool HasSevenCard { get; set; } = false;

    }
}
