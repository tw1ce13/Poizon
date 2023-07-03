using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly PoizonContext _context;
    public SubCategoryRepository(PoizonContext context)
    {
        _context = context;
    }

    public async Task Add(SubCategory subCategory)
    {
        _context.SubCategories.Add(subCategory);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(SubCategory subCategory)
    {
        _context.SubCategories.Remove(subCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SubCategory>> GetAll()
    {
        var subCategories = await _context.SubCategories.ToListAsync();
        return subCategories;
    }

    public async Task<SubCategory> GetById(long id)
    {
        var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
        return subCategory!;
    }

    public async Task<SubCategory> GetSubCategoryByName(string name)
    {
        var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.Name == name);
        return subCategory!;
    }

    public async Task Update(SubCategory subCategory)
    {
        _context.SubCategories.Update(subCategory);
        await _context.SaveChangesAsync();
    }
}
