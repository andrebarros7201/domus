using Domus.API.Data;
using Domus.API.Models;
using Domus.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domus.API.Repositories.Implementations;

public class UserRepository : IUserRepository {
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) {
        _db = db;
    }

    public async Task<User?> GetUserByUsername(string username) {
        return await _db.Users.Include(u => u.Properties).FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserById(string id) {
        return await _db.Users.Include(u => u.Properties).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task CreateUser(User user) {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public Task<User> UpdateUser(User user) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(string id) {
        throw new NotImplementedException();
    }
}

