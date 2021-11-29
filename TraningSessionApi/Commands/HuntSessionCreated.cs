using System;

namespace TraningSessionApi.Commands
{
    public record HuntSessionCreated(Guid Id, DateTime Date, int ClayPigions, bool Duble, int NumberOfShots, int HowWasPigonHit);
  
}
