using Microsoft.EntityFrameworkCore;
using SimpleAuhSystem.Infrastructure.Data;
using SimpleAuthSystem.Application.Contracts.Application;
using SimpleAuthSystem.Domain.Entities;

namespace SimpleAuhSystem.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public Task<User?> GetByEmailAsync(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
