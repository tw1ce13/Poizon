using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    Task<IBaseResponse<User>> GetUserByEmail(string email);
}

