using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntSessionDeletedConsumer : IConsumer<HuntSessionDelted>
    {
        private readonly IGenericRepository<Session> _sessionRepository;
        public HuntSessionDeletedConsumer(IGenericRepository<Session> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task Consume(ConsumeContext<HuntSessionDelted> context)
        {

            var message = context.Message;

            var session = await _sessionRepository.GetAsync(x => x.Id == message.Id);

            if (session != null)
            {
                return;
            }

            await _sessionRepository.DeleteAsync(message.Id);
        }
    }
}
