using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntUserDeletedConsumer : IConsumer<HuntUserDeleted>
    {
        private readonly IGenericRepository<User> _userRepository;
        public HuntUserDeletedConsumer(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Consume(ConsumeContext<HuntUserDeleted> context)
        {
            var message = context.Message;

            var user = await _userRepository.GetAsync(x => x.Id == message.Id);

            if (user != null)
            {
                return;
            }

            await _userRepository.DeleteAsync(message.Id);
        }
    }
}
