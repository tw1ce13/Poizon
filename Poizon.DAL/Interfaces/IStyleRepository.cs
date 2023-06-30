using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IStyleRepository : IBaseRepository<Style>
{
    Task<Style> GetStyleByName(string name);
}

