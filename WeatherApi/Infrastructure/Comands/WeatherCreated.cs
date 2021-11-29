using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Infrastructure.Comands
{
    public record WeatherCreated(Guid Id, string Rain, string Wind, string sun);
    
}
