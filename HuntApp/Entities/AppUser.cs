using Microsoft.AspNetCore.Identity;

namespace UserApi.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
