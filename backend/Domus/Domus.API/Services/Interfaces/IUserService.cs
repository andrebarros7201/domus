using Domus.API.DTOs.User;
using Domus.API.ServiceResult;

namespace Domus.API.Services.Interfaces;

public interface IUserService {
    public Task<ServiceResult<UserDto>> FetchUser(string id);
    public Task<ServiceResult<string>> CreateUser(CreateUserDto userDto);
    public Task<ServiceResult<string>> UpdateUser(CreateUserDto userDto);
    public Task<ServiceResult<string>> DeleteUser(string id);
}