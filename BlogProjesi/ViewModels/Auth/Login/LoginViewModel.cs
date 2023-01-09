using System.ComponentModel.DataAnnotations;

namespace BlogProjesi.ViewModels.Auth.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username cannot be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
