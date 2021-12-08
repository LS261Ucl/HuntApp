using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using UserApi.Application.Dtos.Identity;
using UserApi.Application.Services;
using UserApi.Entities;

namespace UserApi.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<IdentityUserDto>> Login ([FromBody] LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if(user == null)
            {
                _logger.LogInformation("Bad email / password combination.");
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);

            if(!result.Succeeded)
            {
                _logger.LogInformation("Bad email / password combination.");
                return Unauthorized();
            }

            return Ok(new IdentityUserDto
            {
                Email = user.Email,
                Name = user.Name,
                Token = _tokenService.CreateToken(user)
            });

        }

        [Authorize(Policy ="IsAdmin")]
        [HttpPost("Register")]
        public async Task<ActionResult<IdentityUserDto>> Register([FromBody] RegisterUserDto registerUserDto)
        {
            if(await _userManager.Users.AnyAsync(x => x.UserName == registerUserDto.Email))
            {
                _logger.LogInformation($"User with email: {registerUserDto.Email} already exists");
                return BadRequest("User already exists");
            }

            var user = new AppUser
            {
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                UserName = registerUserDto.Email
            };

            var result = _userManager.CreateAsync(user, registerUserDto.Password);

            if(!result.IsCompletedSuccessfully)
            {
                _logger.LogInformation("Problem registering the user");
                return BadRequest("Problem registering the user");

            }

            return Ok(new IdentityUserDto
            { 
                Email = user.Email,
                Name = user.Name,
                Token = _tokenService.CreateToken(user)
            });

        }

        [HttpGet]
        public async Task<ActionResult<IdentityUserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return Ok(new IdentityUserDto
            { 
                Email = user.Email,
                Name = user.Name,
                Token = _tokenService.CreateToken(user)
            });
        }

    }
}
