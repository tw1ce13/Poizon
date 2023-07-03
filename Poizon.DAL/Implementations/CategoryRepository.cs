using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly PoizonContext _context;
    public CategoryRepository(PoizonContext context)
    {
        _context = context;
    }

    public async Task Add(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAll() =>
        await _context.Categories.ToListAsync();

    public async Task<Category> GetById(long id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return category!;
    }

    public async Task<Category> GetCategoryByName(string name)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
        return category!;
    }

    public async Task Update(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}

