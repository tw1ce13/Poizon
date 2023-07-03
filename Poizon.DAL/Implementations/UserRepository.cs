using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class UserRepository : IUserRepository
{
    private readonly PoizonContext _context;
    public UserRepository(PoizonContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetById(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user!;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user!;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
