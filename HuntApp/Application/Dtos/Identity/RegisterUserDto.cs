using System.ComponentModel.DataAnnotations;


namespace UserApi.Application.Dtos.Identity
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

      
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=£$€*-]).{6,18}$",
            ErrorMessage =
                "Password must contain at least one lower case letter, one upper case letter, one digit and one special character")]
        public string Password { get; set; }
    }
}
