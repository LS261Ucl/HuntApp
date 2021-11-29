using System;

namespace WeatherApi.Commands
{
    public record HuntWeatherUpdated(Guid Id, string Rain, string Wind, string Sun);
  
}
