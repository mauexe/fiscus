using System.Diagnostics;

namespace domain;

public interface IRepository<T> where T : class
{
    public T Get(int id);
    public Task<T> GetAsync(int id);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> GetAll(int page, int pageSize);
    public Task<IEnumerable<T>> GetAllAsync();
    
    public Task<IEnumerable<T>> GetAllAsync(int page, int pageSize);
    public T Add(T entity);
    public Task<T> AddAsync(T entity);
    public IEnumerable<T> AddRange(IEnumerable<T> entities);
    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    public T Update(T entity);
    public Task<T> UpdateAsync(T entity);
    public void Delete(T entity);
    public Task DeleteAsync(T entity);
}