using NewIceCream.Domain.Models;

namespace NewIceCream.DAL.Repository;

public class RepositoryProxy<T> : IRepository<T> where T : Model
{
    private readonly Lazy<Repository<T>> _repository;

    private List<T> _entities;

    public RepositoryProxy(IcecreamDbContext context)
    {
        _repository = new Lazy<Repository<T>>(() => 
            new Repository<T>(context));

        _entities = new List<T>();
    }

    public async Task Create(T entity)
    {
        await _repository.Value.Create(entity);

        _entities.Add(entity);
    }

    public async Task Delete(T entity)
    {
        await _repository.Value.Delete(entity);

        if (_entities.Contains(entity))
        {
            _entities.Remove(entity);
        }
    }

    public IQueryable<T> GetAll()
    {
        if(_entities.Count == 0)
        {
            _entities = _repository.Value.GetAll().ToList();
        }

        return _entities.AsQueryable();
    }

    public IQueryable<T> GetAll(int id)
    {
        if (_entities.Count == 0)
        {
            _entities = _repository.Value.GetAll().Where(x => x.Id == id) .ToList();
        }

        return _entities.AsQueryable();
    }

    public T Update(T entity)
    {
        int index = _entities.FindIndex(x => x.Equals(entity));

        if (index == -1)
        {
            _repository.Value.Update(entity);
            _entities.Add(entity);

            return entity;
        }

        _entities[index] = entity;
        _repository.Value.Update(entity);

        return entity;
    }
}
