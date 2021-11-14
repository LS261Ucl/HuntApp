using System;


namespace TraningSessionApi.Application.Dtos
{
    public class CreateSessionDto
    {
        public DateTime Date { get; set; }
        public int ClayPigions { get; set; }
        public bool Duble { get; set; }
        public int NumberOfShots { get; set; }
        public int HowWasPigonHit { get; set; }
    }
}
