﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Commands;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Consumers
{
    public class HuntWeaponCreatedConsumer : IConsumer<HuntWeaponCreated>
    {
        private readonly IGenericRepository<Weapon> _weaponRepository;
        public HuntWeaponCreatedConsumer(IGenericRepository<Weapon> weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        public async Task Consume(ConsumeContext<HuntWeaponCreated> context)
        {
            var message = context.Message;
            var weapon = await _weaponRepository.GetAsync(x => x.Id == message.Id);

            if (weapon != null)
            {
                return;
            }

            weapon = new Weapon

            {
                Id = message.Id,
                Type = message.Type,
                Caliber = message.Caliber,
                Favorit = message.Favorit
            };

            await _weaponRepository.CreateAsync(weapon);
        }
    }
}
