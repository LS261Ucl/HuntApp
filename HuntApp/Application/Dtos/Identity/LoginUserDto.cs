using System.ComponentModel.DataAnnotations;


namespace UserApi.Application.Dtos.Identity
{
    public class LoginUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
