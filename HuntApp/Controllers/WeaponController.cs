using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Application.Dtos.Weapon;
using UserApi.Application.Interfaces;
using UserApi.Entities;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IGenericRepository<Weapon> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<WeaponController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public WeaponController(IGenericRepository<Weapon> repository, IMapper mapper, ILogger<WeaponController> logger, IPublishEndpoint publishEndpoint )
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ReadWeaponDto>>> GetAllWeapon()
        {
            var weapons = await _repository.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<ReadWeaponDto>>(weapons));
        }

        [HttpGet("{id:guid}", Name = "GetWeapon")]
        public async Task<ActionResult<ReadWeaponDto>> GetWeapon(Guid id)
        {
            var weaponEntity = await _repository.GetAsync(x => x.Id == id);

            if (weaponEntity == null)
            {
                _logger.LogInformation($"No {nameof(Weapon)} was found");
                return NotFound();
            }

            return Ok(_mapper.Map<ReadWeaponDto>(weaponEntity));
        }

        [HttpPost]
        public async Task<ActionResult<ReadWeaponDto>> CreateWeapon([FromBody] CreateWeaponDto createWeaponDto)
        {
            var weapon = _mapper.Map<Weapon>(createWeaponDto);

            bool created = await _repository.CreateAsync(weapon);

            if (!created)
            {
                _logger.LogInformation($"Unable to create {nameof(Weapon)}");
                return BadRequest();

            }

            return CreatedAtAction(nameof(GetWeapon), new { id = weapon.Id }, _mapper.Map<ReadWeaponDto>(weapon));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletWeapon(Guid id)
        {
            bool deleted = await _repository.DeleteAsync(id);

            if (!deleted)
            {
                _logger.LogInformation($"Unable to find and delete {nameof(Weapon)} wíth this id: {id}");
                return NotFound();
            }

            return NoContent();
        }
    }
}
