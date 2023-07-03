using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class StyleRepository : IStyleRepository
{
	private readonly PoizonContext _context;
	public StyleRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Style style)
    {
        _context.Styles.Add(style);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Style style)
    {
        _context.Styles.Remove(style);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Style>> GetAll() =>
        await _context.Styles.ToListAsync();

    public async Task<Style> GetById(long id)
    {
        var style = await _context.Styles.FirstOrDefaultAsync(x => x.Id == id);
        return style!;
    }

    public async Task<Style> GetStyleByName(string name)
    {
        var style = await _context.Styles.FirstOrDefaultAsync(x => x.Name == name);
        return style!;
    }

    public async Task Update(Style style)
    {
        _context.Styles.Update(style);
        await _context.SaveChangesAsync();
    }
}

