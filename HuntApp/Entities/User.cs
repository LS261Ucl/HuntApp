
using System;
using System.Collections.Generic;

namespace UserApi.Entities
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }         
        public ICollection<Weapon> UserWeapon { get; set; }
    }
}
