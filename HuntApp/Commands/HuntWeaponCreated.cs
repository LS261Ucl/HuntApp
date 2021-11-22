using System;

namespace UserApi.Commands
{
    public record HuntWeaponCreated(Guid Id, string Type, string Caliber, bool Favorit);
   
}
