namespace Licenta.BLL.Models
{
    public sealed class UserEditModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<TypeOfUserModel> Roles { get; set; }
    }
}
