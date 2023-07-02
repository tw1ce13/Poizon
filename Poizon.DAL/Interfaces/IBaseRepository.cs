namespace Poizon.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(long id);
    Task Add(T data);
    Task Delete(T data);
    Task Update(T data);
}

