using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class PromocodeRepository : IPromocodeRepository
{
    private readonly PoizonContext _context;
    public PromocodeRepository(PoizonContext context)
    {
        _context = context;
    }
    public async Task Add(Promocode data)
    {
        _context.Promocodes.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Promocode data)
    {
        _context.Promocodes.Remove(data);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Promocode>> GetAll() =>
        await _context.Promocodes.ToListAsync();

    public async Task<Promocode> GetById(long id) =>
        await _context.Promocodes.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Promocode> GetPromocodeByName(string name) =>
        await _context.Promocodes.FirstOrDefaultAsync(x => x.Name == name);

    public async Task Update(Promocode data)
    {
        _context.Promocodes.Update(data);
        await _context.SaveChangesAsync();
    }
}

