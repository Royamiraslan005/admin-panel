using System.ComponentModel.DataAnnotations;

namespace WebApplication6.ViewModels.Account
{
    public class RegistrVm
    {
        [MinLength(5)]
        public string Name {  get; set; }
        [MinLength(5)]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Username {  get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword {  get; set; }
    }
}
