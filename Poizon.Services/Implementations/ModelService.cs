using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<IBaseResponse<Model>> Add(Model model)
        {
            var baseResponse = new BaseResponse<Model>();
            if (model != null)
            {
                await _modelRepository.Add(model);
                baseResponse = new BaseResponse<Model>
                {
                    Data = model,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<Model>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Model>> Delete(Model model)
        {
            var baseResponse = new BaseResponse<Model>();
            if (model != null)
            {
                await _modelRepository.Delete(model);
                baseResponse = new BaseResponse<Model>
                {
                    Data = model,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<Model>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<Model>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Model>>();
            var models = await _modelRepository.GetAll();
            if (models != null)
            {
                baseResponse = new BaseResponse<IEnumerable<Model>>
                {
                    Data = models,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<IEnumerable<Model>>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Model>> GetById(long id)
        {
            var baseResponse = new BaseResponse<Model>();
            var model = await _modelRepository.GetById(id);
            if (model != null)
            {
                baseResponse = new BaseResponse<Model>
                {
                    Data = model,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<Model>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Model>> GetModelByName(string name)
        {
            var baseResponse = new BaseResponse<Model>();
            var model = await _modelRepository.GetModelByName(name);
            if (model != null)
            {
                baseResponse = new BaseResponse<Model>
                {
                    Data = model,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<Model>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Model>> Update(Model model)
        {
            var baseResponse = new BaseResponse<Model>();
            if (model != null)
            {
                await _modelRepository.Update(model);
                baseResponse = new BaseResponse<Model>
                {
                    Data = model,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<Model>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }
    }
}
