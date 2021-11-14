using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Application.Dtos
{
    public class CreateWeatherDto
    {
        public string Rain { get; set; }
        public string Wind { get; set; }
        public string sun { get; set; }
    }
}
