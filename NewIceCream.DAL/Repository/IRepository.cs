namespace NewIceCream.DAL.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task Create(T entity);

    T Update(T entity);

    Task Delete(T entity);
}
