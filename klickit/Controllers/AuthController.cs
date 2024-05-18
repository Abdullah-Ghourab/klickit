using klickit.Core.Constants;
using klickit.Core.DTOs;
using klickit.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace klickit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<IdentityUser> UserManager,
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _UserManager = UserManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User = await _UserManager.FindByEmailAsync(loginDto.Email);
            if (User == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(User, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            UserDto UserDto = new()
            {
                Email = loginDto.Email,
                Token = _tokenService.CreateToken(User, await GetRole(User))
            };
            UserDto.Token = _tokenService.CreateToken(User, await GetRole(User));
            return UserDto;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var User = await _UserManager.FindByEmailAsync(registerDto.Email);
            if (User != null) return BadRequest("this mail already exists");
            User = new();
            User.Email = registerDto.Email;
            User.UserName = registerDto.Email.ToLower();
            var result = await _UserManager.CreateAsync(User, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            registerDto.Role ??= AppRoles.Shopper;
            registerDto.Role = string.Equals(registerDto.Role.Trim(), AppRoles.Supplier, StringComparison.OrdinalIgnoreCase) ? AppRoles.Shopper : AppRoles.Supplier;

            await _UserManager.AddToRoleAsync(User, registerDto.Role!);
            UserDto UserDto = new()
            {
                Email = registerDto.Email,
                Token = _tokenService.CreateToken(User, await GetRole(User))
            };
            return UserDto;
        }

        private async Task<string> GetRole(IdentityUser User)
        {
            var x = await _UserManager.IsInRoleAsync(User, AppRoles.Supplier);
            return (await _UserManager.IsInRoleAsync(User, AppRoles.Supplier)) ? AppRoles.Supplier : AppRoles.Shopper;
        }
    }
}
