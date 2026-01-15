using Domus.API.DTOs.Property;
using Domus.API.DTOs.User;
using Domus.API.Models;
using Domus.API.Repositories.Interfaces;
using Domus.API.ServiceResult;
using Domus.API.Services.Interfaces;

namespace Domus.API.Services.Implementations;

public class UserService : IUserService {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    public async Task<ServiceResult<UserDto>> FetchUser(string id) {
        if (id == null) {
            return ServiceResult<UserDto>.Error("User not found", ServiceResultStatus.NotFound);
        }

        User? user = await _userRepository.GetUserById(id);

        if (user == null) {
            return ServiceResult<UserDto>.Error("User not found", ServiceResultStatus.NotFound);
        }

        return ServiceResult<UserDto>.Ok(new UserDto {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.LastName,
            Properties = user.Properties.Select(p => new PropertyDto {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                NumberRooms = p.NumberRooms,
                Price = p.Price,
                Status = p.Status
            }).ToList()
        });
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