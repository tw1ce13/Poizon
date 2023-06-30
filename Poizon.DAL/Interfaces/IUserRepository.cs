using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
	Task<User> GetUserByEmail(string email);
}

