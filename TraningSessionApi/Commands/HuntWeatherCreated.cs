using System;

namespace TraningSessionApi.Commands
{
    public record HuntWeatherCreated(Guid Id, string Rain, string Wind, string Sun);
    
}
