using MassTransit;
using System.Threading.Tasks;
using WeatherApi.Application.Interface;
using WeatherApi.Commands;
using WeatherApi.Entities;

namespace WeatherApi.Consumers
{
    public class HuntWeatherUpdatedConsumer : IConsumer<HuntWeatherUpdated>
    {
        private readonly IGenericRepository<Weather> _weatherRepository;

        public HuntWeatherUpdatedConsumer(IGenericRepository<Weather> weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task Consume(ConsumeContext<HuntWeatherUpdated> context)
        {
            var message = context.Message;

            var weather = await _weatherRepository.GetAsync(x => x.Id == message.Id);

            if (weather != null)
            {
                return;
            }

            weather = new Weather
            {
                Rain = message.Rain,
                Wind = message.Wind,
                Sun = message.Sun
            };

            await _weatherRepository.CreateAsync(weather);
        }
    }
}
