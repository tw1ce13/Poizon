using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class SizeRepository : ISizeRepository
{
	private readonly PoizonContext _context;
	public SizeRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Size size)
    {
        _context.Sizes.Add(size);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Size size)
    {
        _context.Sizes.Remove(size);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Size>> GetAll() =>
        await _context.Sizes.ToListAsync();

    public async Task<Size> GetById(long id)
    {
        var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == id);
        return size!;
    }

    public async Task<Size> GetSizeByName(string name)
    {
        var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Name == name);
        return size!;
    }

    public async Task Update(Size size)
    {
        _context.Sizes.Update(size);
        await _context.SaveChangesAsync();
    }
}

