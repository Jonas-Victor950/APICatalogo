using System.Linq.Expressions;

namespace APICatalogo.Repositories;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    // IQueryable<T> GetAll2();
    T? Get(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
