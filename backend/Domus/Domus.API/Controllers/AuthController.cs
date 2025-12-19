using Domus.API.DTOs.User;
using Domus.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domus.API.ServiceResult;
using Domus.API.Services.Implementations;
using Domus.API.DTOs.Token;

namespace Domus.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {
    private readonly IAuthService _authService;
    private readonly TokenService _tokenService;

    public AuthController(IAuthService authService, TokenService tokenService) {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto dto) {
        // Validate Model
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        ServiceResult<string> result = await _authService.Register(dto);

        return ServiceResult<string>.ServiceResultResponse(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto) {
        // Validate Model
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        ServiceResult<UserDto> result = await _authService.Login(dto);

        if (result.Status != ServiceResultStatus.Ok) {
            return ServiceResult<UserDto>.ServiceResultResponse(result);
        }

        string token = _tokenService.GenerateToken(new TokenDataDto {
            Id = result.Data.Id,
            Username = result.Data.Username
        });

        Response.Cookies.Append("token", token, new CookieOptions {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.UtcNow.AddDays(7)
        });

        return ServiceResult<UserDto>.ServiceResultResponse(result);


    }

}