using System;

namespace WeatherApi.Infrastructure.Comands
{
    public record WeatherUpdated(Guid Id, string Rain, string Wind, string Sun);
    
}
