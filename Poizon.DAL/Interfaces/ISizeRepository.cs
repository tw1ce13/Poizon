using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface ISizeRepository : IBaseRepository<Size>
{
    Task<Size> GetSizeByName(string name);
}

