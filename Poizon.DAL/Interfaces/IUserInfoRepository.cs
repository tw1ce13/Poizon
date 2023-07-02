using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IUserInfoRepository : IBaseRepository<UserInfo>
{
    Task<IEnumerable<UserInfo>> GetUsersByName(string name);
    Task<IEnumerable<UserInfo>> GetUsersBySurname(string surname);
    Task<UserInfo> GetUserInfoByUserId(long id);
}

