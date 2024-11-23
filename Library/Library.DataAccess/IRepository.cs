using System.Linq.Expressions;
using Library.DataAccess.Entities;

namespace Library.DataAccess;

public interface IRepository<T> where T : IBaseEntity
{
    IQueryable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetById(int id);
    T? GetById(Guid id);
    T Save(T entity);
    void Delete(T entity);
}