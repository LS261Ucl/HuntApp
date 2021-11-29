using System;


namespace TraningSessionApi.Commands
{
    public record HuntWeatherGet(Guid Id, string Rain, string Wind, string Sun);
    
    
}
