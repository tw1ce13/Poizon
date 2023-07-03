using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class SexRepository : ISexRepository
{
	private readonly PoizonContext _context;
	public SexRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Sex sex)
    {
        _context.Sexes.Add(sex);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Sex sex)
    {
        _context.Sexes.Remove(sex);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Sex>> GetAll() =>
        await _context.Sexes.ToListAsync();

    public async Task<Sex> GetById(long id)
    {
        var sex = await _context.Sexes.FirstOrDefaultAsync(x => x.Id == id);
        return sex!;
    }

    public async Task<Sex> GetSexByName(string name)
    {
        var sex = await _context.Sexes.FirstOrDefaultAsync(x => x.Name == name);
        return sex!;
    }

    public async Task Update(Sex sex)
    {
        _context.Sexes.Update(sex);
        await _context.SaveChangesAsync();
    }
}

