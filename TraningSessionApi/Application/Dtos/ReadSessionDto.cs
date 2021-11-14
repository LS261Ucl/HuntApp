using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraningSessionApi.Application.Dtos
{
    public class ReadSessionDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int ClayPigions { get; set; }
        public bool Duble { get; set; }
        public int NumberOfShots { get; set; }
        public int HowWasPigonHit { get; set; }
    }
}
