using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApi.Application.Dtos.User;
using UserApi.Application.Interfaces;
using UserApi.Application.Services;
using UserApi.Entities;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public UsersController(IGenericRepository<User> repository, IMapper mapper, ILogger<UsersController> logger, IPublishEndpoint publishEndpoint)
        {
            _userRepository = repository;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ReadUserDto>>> GetAllUser(string orderBy)
        {
            _logger.LogInformation("Skidtet virker ikke");
            var users = await _userRepository.GetAllAsync(orderBy: new UserOrderBy().Sorting(orderBy));

            return Ok(_mapper.Map<IReadOnlyList<ReadUserDto>>(users));
        }

        [HttpGet("{id:guid}", Name = "GetUser")]
        public async Task<ActionResult<ReadUserDto>> GetUser(Guid id)
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == id);

            if(userEntity == null)
            {
                _logger.LogInformation($"No {nameof(User)} was found");
                return NotFound();
            }

            return Ok(_mapper.Map<ReadUserDto>(userEntity));
        }

        [HttpPost]
        public async Task<ActionResult<ReadUserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            bool created = await _userRepository.CreateAsync(user);

            if(!created)
            {
                _logger.LogInformation($"Unable to create {nameof(User)}");
                return BadRequest();

            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, _mapper.Map<ReadUserDto>(user));
        }

        [HttpPut("{id; guid}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var userToUpdate = await _userRepository.GetAsync(x => x.Id == id);

            if(userToUpdate == null)
            {
                _logger.LogInformation($"No {nameof(User)} was found whit that id");
                return NotFound();
            }

            _mapper.Map(updateUserDto, userToUpdate);

            bool updated = await _userRepository.UpdateAsync(userToUpdate);

            if(!updated)
            {
                _logger.LogInformation($"Error updating {nameof(User)} id : {id}");
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletUser(Guid id)
        {
            bool deleted = await _userRepository.DeleteAsync(id);

            if(!deleted)
            {
                _logger.LogInformation($"Unable to find and delete {nameof(User)} wíth this id: {id}");
                return NotFound();
            }

            return NoContent();
        }
    }
}
