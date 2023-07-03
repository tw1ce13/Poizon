using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class BrandRepository : IBrandRepository
{
	private readonly PoizonContext _context;
	public BrandRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Brand brand)
    {
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Brand>> GetAll() =>
        await _context.Brands.ToListAsync();

    public Task<Brand> GetBrandByName(string name)
    {
        var brand = _context.Brands.FirstOrDefaultAsync(x => x.Name == name);
        return brand!;
    }

    public Task<Brand> GetById(long id)
    {
        var brand = _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        return brand!;
    }

    public async Task Update(Brand brand)
    {
        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();
    }
}

