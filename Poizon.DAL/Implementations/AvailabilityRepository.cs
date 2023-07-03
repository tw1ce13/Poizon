using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly PoizonContext _context;
    public AvailabilityRepository(PoizonContext context)
    {
        _context = context;
    }


    public async Task Add(Availability availability)
    {
        _context.Availabilities.Add(availability);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Availability availability)
    {
        _context.Availabilities.Remove(availability);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Availability>> GetAll() =>
        await _context.Availabilities.ToListAsync();


    public async Task<Availability> GetById(long id)
    {
        var availability = await _context.Availabilities.FirstOrDefaultAsync(x => x.Id == id);
        return availability!;
    }

    public async Task<int> GetCountByClothesId(long id)
    {
        var availability = await _context.Availabilities.FirstOrDefaultAsync(x => x.ClothesId == id);
        return availability!.Count;
    }

    public async Task Update(Availability availability)
    {
        _context.Availabilities.Update(availability);
        await _context.SaveChangesAsync();
    }
}

