using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntUserCreatedConsumer : IConsumer<HuntUserCreated>
    {
        private readonly IGenericRepository<User> _userRepository;

        public HuntUserCreatedConsumer(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Consume(ConsumeContext<HuntUserCreated> context)
        {

            var message = context.Message;
            var user = await _userRepository.GetAsync(x => x.Id == message.Id);

            if (user != null)
            {
                return;
            }

            user = new User

            {
                Id = message.Id,
                Name = message.Name,
                Email = message.Email,
                PhoneNumber = message.PhoneNumber
            };

            await _userRepository.CreateAsync(user);
        }
    }
}
