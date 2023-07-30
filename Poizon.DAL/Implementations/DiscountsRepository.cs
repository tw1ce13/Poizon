using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class DiscountsRepository : IDiscountsRepository
{
    private readonly PoizonContext _context;
	public DiscountsRepository(PoizonContext context)
	{
        _context = context;
	}

    public async Task Add(Discounts data)
    {
        _context.Discounts.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Discounts data)
    {
        _context.Discounts.Remove(data);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Discounts>> GetAll() =>
        await _context.Discounts.ToListAsync();

    public async Task<Discounts> GetById(long id) =>
        await _context.Discounts.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Discounts> GetDiscountByName(string name) =>
        await _context.Discounts.FirstOrDefaultAsync(x => x.Name == name);

    public async Task Update(Discounts data)
    {
        _context.Discounts.Update(data);
        await _context.SaveChangesAsync();
    }
}

