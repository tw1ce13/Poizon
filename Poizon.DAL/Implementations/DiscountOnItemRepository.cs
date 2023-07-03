using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class DiscountOnItemRepository : IDiscountOnItemRepository 
{
	private readonly PoizonContext _contex;
	public DiscountOnItemRepository(PoizonContext context)
	{
		_contex = context;
	}

    public async Task Add(DiscountOnItem discountOnItem)
    {
        _contex.DiscountOnItems.Add(discountOnItem);
        await _contex.SaveChangesAsync();
    }

    public async Task Delete(DiscountOnItem discountOnItem)
    {
        _contex.DiscountOnItems.Remove(discountOnItem);
        await _contex.SaveChangesAsync();
    }

    public async Task<IEnumerable<DiscountOnItem>> GetAll() =>
        await _contex.DiscountOnItems.ToListAsync();

    public async Task<DiscountOnItem> GetById(long id)
    {
        var discountOnItem = await _contex.DiscountOnItems.FirstOrDefaultAsync(x => x.Id == id);
        return discountOnItem!;
    }

    public async Task<DiscountOnItem> GetDiscountOnItemByName(string name)
    {
        var discountOnItem = await _contex.DiscountOnItems.FirstOrDefaultAsync(x => x.Name == name);
        return discountOnItem!;
    }

    public async Task Update(DiscountOnItem discountOnItem)
    {
        _contex.DiscountOnItems.Update(discountOnItem);
        await _contex.SaveChangesAsync();
    }
}


