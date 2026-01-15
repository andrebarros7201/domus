using System.Security.Claims;
using Domus.API.DTOs.User;
using Domus.API.ServiceResult;
using Domus.API.Services.Implementations;
using Domus.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domus.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me() {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        ServiceResult<UserDto> result = await _userService.FetchUser(userId!);

        return ServiceResult<UserDto>.ServiceResultResponse(result);
    }

}