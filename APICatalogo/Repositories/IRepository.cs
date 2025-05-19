using System.Linq.Expressions;

namespace APICatalogo.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    // IQueryable<T> GetAll2();
    Task<T>? GetAsync(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
