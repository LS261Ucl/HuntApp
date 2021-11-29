using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntWeatherCreatedConsumer : IConsumer<HuntWeatherCreated>
    {
        private readonly IGenericRepository<Weather> _weatherRepository;
        public HuntWeatherCreatedConsumer(IGenericRepository<Weather> weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public async Task Consume(ConsumeContext<HuntWeatherCreated> context)
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
