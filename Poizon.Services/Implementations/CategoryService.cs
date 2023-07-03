using Poizon.DAL.Implementations;
using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IBaseResponse<Category>> Add(Category category)
    {
        var baseResponse = new BaseResponse<Category>();
        if (category != null)
        {
            await _categoryRepository.Add(category);
            baseResponse = new BaseResponse<Category>
            {
                Data = category,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Category>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Category>> Delete(Category category)
    {
        var baseResponse = new BaseResponse<Category>();
        if (category != null)
        {
            await _categoryRepository.Delete(category);
            baseResponse = new BaseResponse<Category>
            {
                Data = category,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Category>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Category>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Category>>();
        var categories = await _categoryRepository.GetAll();
        if (categories != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Category>>
            {
                Data = categories,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Category>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Category>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Category>();
        var category = await _categoryRepository.GetById(id);
        if (category != null)
        {
            await _categoryRepository.Delete(category);
            baseResponse = new BaseResponse<Category>
            {
                Data = category,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Category>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;

    }

    public async Task<IBaseResponse<Category>> GetCategoryByName(string name)
    {
        var baseResponse = new BaseResponse<Category>();
        var category = await _categoryRepository.GetCategoryByName(name);
        if (category != null)
        {
            await _categoryRepository.Delete(category);
            baseResponse = new BaseResponse<Category>
            {
                Data = category,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Category>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Category>> Update(Category category)
    {
        var baseResponse = new BaseResponse<Category>();
        if (category != null)
        {
            await _categoryRepository.Update(category);
            baseResponse = new BaseResponse<Category>
            {
                Data = category,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Category>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }
}

