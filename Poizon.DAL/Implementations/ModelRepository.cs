using Microsoft.EntityFrameworkCore;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.DAL.Implementations;

public class ModelRepository : IModelRepository
{
	private readonly PoizonContext _context;
	public ModelRepository(PoizonContext context)
	{
		_context = context;
	}

    public async Task Add(Model model)
    {
        _context.Models.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Model model)
    {
        _context.Models.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Model>> GetAll() =>
        await _context.Models.ToListAsync();

    public async Task<Model> GetById(long id)
    {
        var model = await _context.Models.FirstOrDefaultAsync(x => x.Id == id);
        return model!;
    }

    public async Task<Model> GetModelByName(string name)
    {
        var model = await _context.Models.FirstOrDefaultAsync(x => x.Name == name);
        return model!;
    }

    public async Task Update(Model model)
    {
        _context.Models.Update(model);
        await _context.SaveChangesAsync();
    }
}

