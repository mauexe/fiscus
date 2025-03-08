using Microsoft.EntityFrameworkCore;

namespace domain;

public abstract class ARepository<T> : IRepository<T> where T : class
{
    protected DbSet<T> set;
    protected DbContext context;

    public ARepository(DbContext context)
    {
        this.context = context;
        this.set = context.Set<T>();
    }
    
    public T Get(int id)
    {
        return set.Find(id);
    }

    public async Task<T> GetAsync(int id)
    {
        return await set.FindAsync(id);
    }

    public IEnumerable<T> GetAll()
    {
        return set.ToList();
    }

    public IEnumerable<T> GetAll(int page, int pageSize)
    {
        return set.Skip(page * pageSize).Take(pageSize).ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await Task.Delay(1000);
        return await set.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
    {
        return await set.Skip(page * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await set.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        set.AddRange(entities);
        context.SaveChanges();
        return entities;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await set.AddRangeAsync(entities);
        await context.SaveChangesAsync();
        return entities;
    }

    public T Update(T entity)
    {
        set.Update(entity);
        context.SaveChanges();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        set.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public T Add(T entity)
    {
        set.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    { 
        set.Remove(entity);
        context.SaveChanges();
    }

    public async Task DeleteAsync(T entity)
    {
        set.Remove(entity);
        await context.SaveChangesAsync();
    }
}