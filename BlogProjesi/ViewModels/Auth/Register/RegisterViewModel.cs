using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BlogProjesi.ViewModels.Auth.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username cannot be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [DataType(DataType.Password)]
        [RegularExpression("[a-zA-Z0-9]{8,16}", ErrorMessage = "Your password cannot be shorter than 8 characters.")]
        public string Password { get; set; }
    }
    
}
