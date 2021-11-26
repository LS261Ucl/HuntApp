using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Application.Dtos;
using WeatherApi.Application.Interface;
using WeatherApi.Commands;
using WeatherApi.Entities;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IGenericRepository<Weather> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public WeatherController(IGenericRepository<Weather> repository, IMapper mapper, ILogger<WeatherController> logger, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ReadWeatherDto>>> GetAllWeather(string orderBy)
        {
            var users = await _repository.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<ReadWeatherDto>>(users));
        }

        [HttpGet("{id:guid}", Name = "GetWeather")]
        public async Task<ActionResult<ReadWeatherDto>> GetWeather(Guid id)
        {
            var weatherEntity = await _repository.GetAsync(x => x.Id == id);

            if (weatherEntity == null)
            {
                _logger.LogInformation($"No {nameof(User)} was found");
                return NotFound();
            }

            return Ok(_mapper.Map<ReadWeatherDto>(weatherEntity));
        }

        [HttpPost]
        public async Task<ActionResult<ReadWeatherDto>> CreateUser([FromBody] CreateWeatherDto createWeatherDto)
        {
            var weather = _mapper.Map<Weather>(createWeatherDto);

            bool created = await _repository.CreateAsync(weather);

            if (!created)
            {
                _logger.LogInformation($"Unable to create {nameof(weather)}");
                return BadRequest();

            }
           // await _publishEndpoint.Publish(new HuntWeatherCreated(weather.Id, weather.Rain, weather.Wind, weather.Sun));

            return CreatedAtAction(nameof(GetWeather), new { id = weather.Id }, _mapper.Map<ReadWeatherDto>(weather));
        }
    }
}
