
using System.Collections.Generic;

namespace UserApi.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }         
        public ICollection<Weapon> UserWeapn { get; set; }
    }
}
