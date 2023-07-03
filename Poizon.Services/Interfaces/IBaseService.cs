using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IBaseService<T>
{
    Task<IBaseResponse<IEnumerable<T>>> GetAll();
    Task<IBaseResponse<T>> GetById(long id);
    Task<IBaseResponse<T>> Add(T data);
    Task<IBaseResponse<T>> Delete(T data);
    Task<IBaseResponse<T>> Update(T data);
}

