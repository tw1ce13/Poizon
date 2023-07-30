using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class ClothesRepository : IClothesRepository
{
	private readonly PoizonContext _context;
	public ClothesRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Clothes clothes)
    {
        _context.Clothes.Add(clothes);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Clothes clothes)
    {
        _context.Clothes.Remove(clothes);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Clothes>> GetAll() =>
        await _context.Clothes.ToListAsync();

    public async Task<Clothes> GetById(long id)
    {
        var clothes = await _context.Clothes.FirstOrDefaultAsync(x => x.Id == id);
        return clothes!;
    }

    public async Task<IEnumerable<Clothes>> GetClothesByBrandId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.BrandId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesByCategoryId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.CategoryId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesByCost(long minCost, long maxCost)
    {
        var clothes = await _context.Clothes.Where(x => x.Cost >= minCost && x.Cost <= maxCost).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesByModelId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.ModelId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesBySexId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.SexId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesBySizeId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.SizeId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesByStyleId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.StyleId == id).ToListAsync();
        return clothes;
    }

    public async Task<IEnumerable<Clothes>> GetClothesBySubCategoryId(long id)
    {
        var clothes = await _context.Clothes.Where(x => x.SubCategoryId == id).ToListAsync();
        return clothes;
    }

    public Task<IEnumerable<Clothes>> GetClothesBySubSubCategoryId(long id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Clothes clothes)
    {
        _context.Clothes.Update(clothes);
        await _context.SaveChangesAsync();
    }
}

