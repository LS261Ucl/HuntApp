using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntSessionCreatedConsumer : IConsumer<HuntSessionCreated>
    {
        private readonly IGenericRepository<Session> _sessionRepository;
        public HuntSessionCreatedConsumer(IGenericRepository<Session> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task Consume(ConsumeContext<HuntSessionCreated> context)
        {
            var message = context.Message;

            var session = await _sessionRepository.GetAsync(x => x.Id == message.Id);

            if(session != null)
            {
                return;
            }

            session = new Session
            {
                Date = message.Date,
                Duble = message.Duble,
                ClayPigions = message.ClayPigions,
                Id = message.Id,
                NumberOfShots = message.NumberOfShots,
                HowWasPigonHit = message.HowWasPigonHit


            };

            await _sessionRepository.CreateAsync(session);

        }
    }
}
