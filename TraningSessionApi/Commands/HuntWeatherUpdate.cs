using System;


namespace TraningSessionApi.Commands
{
    public record HuntWeatherUpdate(Guid Id, string Rain, string Wind, string Sun);
    
}
