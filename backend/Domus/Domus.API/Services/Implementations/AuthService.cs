using Domus.API.DTOs.Property;
using Domus.API.DTOs.User;
using Domus.API.Models;
using Domus.API.Repositories.Interfaces;
using Domus.API.ServiceResult;
using Domus.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domus.API.Services.Implementations;

public class AuthService : IAuthService {
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<ServiceResult<UserDto>> Login(LoginUserDto userDto) {
        try {
            User? existingUser = await _userRepository.GetUserByUsername(userDto.Username);

            if (existingUser == null) {
                return ServiceResult<UserDto>.Error("User not found", ServiceResultStatus.NotFound);
            }

            var hasher = new PasswordHasher<User>();

            // Compare passwords
            PasswordVerificationResult comparePassword = hasher.VerifyHashedPassword(existingUser, existingUser.Password, userDto.Password);

            if (comparePassword == PasswordVerificationResult.Failed) {
                return ServiceResult<UserDto>.Error("Invalid Username/Password combination", ServiceResultStatus.BadRequest);
            }

            return ServiceResult<UserDto>.Ok(new UserDto {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Username = existingUser.Username,
                Properties = existingUser.Properties.Select(p => new PropertyDto {
                    Id = p.Id,
                    Name = p.Name,
                    Location = p.Location,
                    Price = p.Price,
                    NumberRooms = p.NumberRooms,
                    Status = p.Status
                }).ToList()
            });
        }
        catch (Exception ex) {
            System.Console.WriteLine(ex);
            return ServiceResult<UserDto>.Error("Failed to login", ServiceResultStatus.BadRequest);
        }

    }

    public async Task<ServiceResult<string>> Register(CreateUserDto userDto) {
        try {

            User? existingUser = await _userRepository.GetUserByUsername(userDto.Username);

            if (existingUser != null) {
                return ServiceResult<string>.Error("Username already exists", ServiceResultStatus.Conflict);
            }

            var hasher = new PasswordHasher<User>();

            User newUser = new User() {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Password = hasher.HashPassword(null, userDto.Password) // Hash Password
            };

            await _userRepository.CreateUser(newUser);

            return ServiceResult<string>.Created("User created successfully");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return ServiceResult<string>.Error("Failed to create user", ServiceResultStatus.BadRequest);
        }
    }
}