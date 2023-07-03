using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly PoizonContext _context;
    public UserInfoRepository(PoizonContext context)
    {
        _context = context;
    }

    public async Task Add(UserInfo userInfo)
    {
        _context.UsersInfo.Add(userInfo);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(UserInfo userInfo)
    {
        _context.UsersInfo.Remove(userInfo);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserInfo>> GetAll()
    {
        var usersInfo = await _context.UsersInfo.ToListAsync();
        return usersInfo;
    }

    public async Task<UserInfo> GetById(long id)
    {
        var userInfo = await _context.UsersInfo.FirstOrDefaultAsync(x => x.Id == id);
        return userInfo!;
    }

    public async Task<UserInfo> GetUserInfoByUserId(long id)
    {
        var userInfo = await _context.UsersInfo.FirstOrDefaultAsync(x => x.UserId == id);
        return userInfo!;
    }

    public async Task<IEnumerable<UserInfo>> GetUsersByName(string name)
    {
        var usersInfo = await _context.UsersInfo.Where(x => x.Name == name).ToListAsync();
        return usersInfo;
    }

    public async Task<IEnumerable<UserInfo>> GetUsersBySurname(string surname)
    {
        var usersInfo = await _context.UsersInfo.Where(x => x.Surname == surname).ToListAsync();
        return usersInfo;
    }

    public async Task Update(UserInfo userInfo)
    {
        _context.UsersInfo.Update(userInfo);
        await _context.SaveChangesAsync();
    }
}
