using System;

namespace UserApi.Application.Dtos.Weapon
{
    public class ReadWeaponDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public string Caliber { get; set; }
        public bool Favorit { get; set; }
    }
}
