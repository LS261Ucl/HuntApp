using MassTransit;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntWeaponDeletedConsumer : IConsumer<HuntWeaponDeleted>
    {
        private readonly IGenericRepository<Weapon> _weaponRepository;

        public HuntWeaponDeletedConsumer(IGenericRepository<Weapon> weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        public async Task Consume(ConsumeContext<HuntWeaponDeleted> context)
        {
            var message = context.Message;

            var weapon = await _weaponRepository.GetAsync(x => x.Id == message.Id);

            if (weapon != null)
            {
                return;
            }

            await _weaponRepository.DeleteAsync(message.Id);
        }
    }
}
