using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class OrderClothesRepository : IOrderClothesRepository
{
	private readonly PoizonContext _context;
	public OrderClothesRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(OrderClothes orderClothes)
    {
        _context.OrderClothes.Add(orderClothes);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(OrderClothes orderClothes)
    {
        _context.OrderClothes.Remove(orderClothes);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderClothes>> GetAll() =>
        await _context.OrderClothes.ToListAsync();

    public async Task<OrderClothes> GetById(long id)
    {
        var orderClothes = await _context.OrderClothes.FirstOrDefaultAsync(x => x.Id == id);
        return orderClothes!;
    }

    public async Task<OrderClothes> GetOrderClothesByClothesId(long clothesId)
    {
        var orderClothes = await _context.OrderClothes.Where(x => x.ClothesId == clothesId).ToListAsync();
        return orderClothes.LastOrDefault()!;
    }

    public async Task<OrderClothes> GetOrderClothesByOrderId(long orderId)
    {
        var orderClothes = await _context.OrderClothes.Where(x => x.OrderId == orderId).ToListAsync();
        return orderClothes.LastOrDefault()!;
    }

    public async Task Update(OrderClothes orderClothes)
    {
        _context.OrderClothes.Update(orderClothes);
        await _context.SaveChangesAsync();
    }
}

