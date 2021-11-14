using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Entities
{
    public class Weather : BaseEntitity
    {
        public string Rain { get; set; }
        public string Wind { get; set; }
        public string sun { get; set; }
    }
}
