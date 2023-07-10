using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;
namespace Poizon.Services.Implementations
{
    public class SubSubCategoryService : ISubSubCategoryService
    {
        private readonly ISubSubCategoryRepository _subSubCategoryRepository;

        public SubSubCategoryService(ISubSubCategoryRepository subSubCategoryRepository)
        {
            _subSubCategoryRepository = subSubCategoryRepository;
        }

        public async Task<IBaseResponse<SubSubCategory>> Add(SubSubCategory subSubCategory)
        {
            var baseResponse = new BaseResponse<SubSubCategory>();
            if (subSubCategory != null)
            {
                await _subSubCategoryRepository.Add(subSubCategory);
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Data = subSubCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubSubCategory>> Delete(SubSubCategory subSubCategory)
        {
            var baseResponse = new BaseResponse<SubSubCategory>();
            if (subSubCategory != null)
            {
                await _subSubCategoryRepository.Delete(subSubCategory);
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Data = subSubCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<SubSubCategory>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<SubSubCategory>>();
            var subSubCategories = await _subSubCategoryRepository.GetAll();
            if (subSubCategories != null)
            {
                baseResponse = new BaseResponse<IEnumerable<SubSubCategory>>
                {
                    Data = subSubCategories,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<IEnumerable<SubSubCategory>>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubSubCategory>> GetById(long id)
        {
            var baseResponse = new BaseResponse<SubSubCategory>();
            var data = await _subSubCategoryRepository.GetById(id);
            if (data != null)
            {
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Data = data,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubSubCategory>> Update(SubSubCategory subSubCategory)
        {
            var baseResponse = new BaseResponse<SubSubCategory>();
            if (subSubCategory != null)
            {
                await _subSubCategoryRepository.Update(subSubCategory);
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Data = subSubCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubSubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }
    }
}
