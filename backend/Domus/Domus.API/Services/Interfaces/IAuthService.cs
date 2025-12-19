using Domus.API.DTOs.User;
using Domus.API.ServiceResult;

namespace Domus.API.Services.Interfaces;

public interface IAuthService {
    public Task<ServiceResult<UserDto>> Login(LoginUserDto userDto);
    public Task<ServiceResult<string>> Register(CreateUserDto userDto);
}