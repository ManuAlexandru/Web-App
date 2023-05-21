namespace Licenta.BLL.Models
{
    public sealed class TypeOfUserModel
    {
        public string User { get; set; } = "User";
        public string Admin { get; set; } = "Admin";
        public string OwnerOfGym { get; set; } = "OwnerOfGym";
        public string Trainer { get; set; } = "Trainer";
    }
}
