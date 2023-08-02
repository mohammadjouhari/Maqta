using System.Linq.Expressions;
namespace Repositories
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll(bool enablelazyloading);
        IEnumerable<T> GetAllv1();
        IQueryable<T> GetAllv2();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
