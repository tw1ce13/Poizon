using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class SubSubCategoryRepository : ISubSubCategoryRepository
{
	private readonly PoizonContext _context;
	public SubSubCategoryRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(SubSubCategory subSubCategory)
    {
        _context.SubSubCategories.Add(subSubCategory);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(SubSubCategory subSubCategory)
    {
        _context.SubSubCategories.Remove(subSubCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SubSubCategory>> GetAll()
    {
        var subSubCategories = await _context.SubSubCategories.ToListAsync();
        return subSubCategories!;
    }

    public async Task<SubSubCategory> GetById(long id)
    {
        var subSubCategory = await _context.SubSubCategories.FirstOrDefaultAsync(x => x.Id == id);
        return subSubCategory!;
    }

    public async Task Update(SubSubCategory subSubCategory)
    {
        _context.SubSubCategories.Add(subSubCategory);
        await _context.SaveChangesAsync();
    }
}

