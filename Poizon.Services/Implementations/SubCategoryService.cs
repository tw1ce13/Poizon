using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;
namespace Poizon.Services.Implementations
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IBaseResponse<SubCategory>> Add(SubCategory subCategory)
        {
            var baseResponse = new BaseResponse<SubCategory>();
            if (subCategory != null)
            {
                await _subCategoryRepository.Add(subCategory);
                baseResponse = new BaseResponse<SubCategory>
                {
                    Data = subCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubCategory>> Delete(SubCategory subCategory)
        {
            var baseResponse = new BaseResponse<SubCategory>();
            if (subCategory != null)
            {
                await _subCategoryRepository.Delete(subCategory);
                baseResponse = new BaseResponse<SubCategory>
                {
                    Data = subCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<SubCategory>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<SubCategory>>();
            var subCategories = await _subCategoryRepository.GetAll();
            if (subCategories != null)
            {
                baseResponse = new BaseResponse<IEnumerable<SubCategory>>
                {
                    Data = subCategories,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<IEnumerable<SubCategory>>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubCategory>> GetById(long id)
        {
            var baseResponse = new BaseResponse<SubCategory>();
            var subCategory = await _subCategoryRepository.GetById(id);
            if (subCategory != null)
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Data = subCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubCategory>> GetSubCategoryByName(string name)
        {
            var baseResponse = new BaseResponse<SubCategory>();
            var subCategory = await _subCategoryRepository.GetSubCategoryByName(name);
            if (subCategory != null)
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Data = subCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<SubCategory>> Update(SubCategory subCategory)
        {
            var baseResponse = new BaseResponse<SubCategory>();
            if (subCategory != null)
            {
                await _subCategoryRepository.Update(subCategory);
                baseResponse = new BaseResponse<SubCategory>
                {
                    Data = subCategory,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<SubCategory>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }
    }
}
