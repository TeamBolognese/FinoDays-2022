using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class UserRepository : IUserRepository
{
    private DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<User> GetAllUsers()
    {
        return _context.Users.AsQueryable();
    }

    public async Task<User> Add(User user)
    {
        var entityEntry = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByLoginAsync(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Login == login);
    }
}
