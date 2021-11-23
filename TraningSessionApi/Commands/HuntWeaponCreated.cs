using System;

namespace TraningSessionApi.Commands
{
    public record HuntWeaponCreated(Guid Id, string Type, string Caliber, bool Favorit);
}
