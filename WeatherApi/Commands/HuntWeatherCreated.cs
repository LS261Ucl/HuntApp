using System;


namespace WeatherApi.Commands
{
    public record HuntWeatherCreated(Guid Id, string Rain, string Wind, string Sun);
}
