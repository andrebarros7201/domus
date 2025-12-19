using Domus.API.DTOs.User;
using Domus.API.Repositories.Interfaces;
using Domus.API.ServiceResult;
using Domus.API.Services.Interfaces;

namespace Domus.API.Services.Implementations;

public class UserService : IUserService {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    public Task<ServiceResult<UserDto>> FetchUser(string id) {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<string>> CreateUser(CreateUserDto userDto) {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<string>> UpdateUser(CreateUserDto userDto) {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<string>> DeleteUser(string id) {
        throw new NotImplementedException();
    }

}