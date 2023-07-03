using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class DiscountOnOrderRepository : IDiscountOnOrderRepository
{
	private readonly PoizonContext _context;
	public DiscountOnOrderRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(DiscountOnOrder discountOnOrder)
    {
        _context.DiscountsOnOrder.Add(discountOnOrder);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(DiscountOnOrder discountOnOrder)
    {
        _context.DiscountsOnOrder.Remove(discountOnOrder);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DiscountOnOrder>> GetAll() =>
        await _context.DiscountsOnOrder.ToListAsync();

    public async Task<DiscountOnOrder> GetById(long id)
    {
        var discountOnOrder = await _context.DiscountsOnOrder.FirstOrDefaultAsync(x => x.Id == id);
        return discountOnOrder!;
    }

    public async Task<DiscountOnOrder> GetDiscountOnOrderByName(string name)
    {
        var discountOnOrder = await _context.DiscountsOnOrder.FirstOrDefaultAsync(x => x.Name == name);
        return discountOnOrder!;
    }

    public async Task Update(DiscountOnOrder discountOnOrder)
    {
        _context.DiscountsOnOrder.Update(discountOnOrder);
        await _context.SaveChangesAsync();
    }
}

