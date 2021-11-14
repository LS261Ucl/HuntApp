using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraningSessionApi.Entities
{
    public class Session : BaseEnitity
    {
        public DateTime Date { get; set; }
        public int ClayPigions { get; set; }
        public bool Duble { get; set; }
        public int NumberOfShots { get; set; }
        public int HowWasPigonHit { get; set; }

    }
}
