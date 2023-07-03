using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class OrderRepository : IOrderRepository
{
	private readonly PoizonContext _context;
	public OrderRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAll() =>
        await _context.Orders.ToListAsync();

    public async Task<Order> GetById(long id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return order!;
    }

    public async Task<Order> GetOrderByUserId(long id)
    {
        var order = await _context.Orders.Where(x => x.UserId == id).ToListAsync();
        return order.LastOrDefault()!;
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}


