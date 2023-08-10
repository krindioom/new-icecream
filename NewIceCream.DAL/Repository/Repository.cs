using Microsoft.EntityFrameworkCore;

namespace NewIceCream.DAL.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IcecreamDbContext _context;

    public Repository(IcecreamDbContext context)
    {
        _context = context;
    }

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
         return _context.Set<T>();
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}

