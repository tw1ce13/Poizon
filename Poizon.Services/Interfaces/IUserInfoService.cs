using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IUserInfoService : IBaseService<UserInfo>
{
    Task<IBaseResponse<IEnumerable<UserInfo>>> GetUsersByName(string name);
    Task<IBaseResponse<IEnumerable<UserInfo>>> GetUsersBySurname(string surname);
    Task<IBaseResponse<UserInfo>> GetUserInfoByUserId(long id);
    Task<IBaseResponse<UserInfo>> GetChanges(UserInfo userInfo);
}

