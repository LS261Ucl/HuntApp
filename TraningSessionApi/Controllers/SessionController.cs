using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningSessionApi.Application.Dtos;
using TraningSessionApi.Application.Interfaces;
using TraningSessionApi.Application.Services;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IGenericRepository<Session> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<SessionController> _logger;

        public SessionController(IGenericRepository<Session> repository, IMapper mapper, ILogger<SessionController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ReadSessionDto>>> GetAllSession(string orderBy)
        {
            var users = await _repository.GetAllAsync(orderBy: new SessionsOrderBy().Sorting(orderBy));

            return Ok(_mapper.Map<IReadOnlyList<ReadSessionDto>>(users));
        }

        [HttpGet("{id:guid}", Name = "GetSession")]
        public async Task<ActionResult<ReadSessionDto>> GetSession(Guid id)
        {
            var sessionEntity = await _repository.GetAsync(x => x.Id == id);

            if (sessionEntity == null)
            {
                _logger.LogInformation($"No {nameof(User)} was found");
                return NotFound();
            }

            return Ok(_mapper.Map<ReadSessionDto>(sessionEntity));
        }

        [HttpPost]
        public async Task<ActionResult<ReadSessionDto>> CreateSession([FromBody] CreateSessionDto createSessionDto)
        {
            var user = _mapper.Map<Session>(createSessionDto);

            bool created = await _repository.CreateAsync(user);

            if (!created)
            {
                _logger.LogInformation($"Unable to create {nameof(User)}");
                return BadRequest();

            }

            return CreatedAtAction(nameof(GetSession), new { id = user.Id }, _mapper.Map<ReadSessionDto>(user));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletSession(Guid id)
        {
            bool deleted = await _repository.DeleteAsync(id);

            if (!deleted)
            {
                _logger.LogInformation($"Unable to find and delete {nameof(Session)} wíth this id: {id}");
                return NotFound();
            }

            return NoContent();
        }
    }
}
