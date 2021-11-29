using System;

namespace UserApi.Entities
{
    public class Weapon : BaseEntity
    {
        public string Type { get; set; }
        public string Caliber { get; set; }
        public bool Favorit { get; set; }
        public Guid UserId { get; set; }
    }
}
