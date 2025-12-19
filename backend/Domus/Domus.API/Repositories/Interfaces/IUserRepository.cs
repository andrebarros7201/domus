using Domus.API.Models;

namespace Domus.API.Repositories.Interfaces;

public interface IUserRepository {
    public Task<User?> GetUserById(string id);
    public Task<User?> GetUserByUsername(string username);
    public Task CreateUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<bool> DeleteUser(string id);
}