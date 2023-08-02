using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        public DBContext context; 
        public Repository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> GetAll(bool enablelazyloading)
        {
            IEnumerable<T> result = new List<T>();
            if (enablelazyloading)
            {
                context.ChangeTracker.LazyLoadingEnabled = enablelazyloading;
                result = context.Set<T>().ToList();

            }
            else
            {
                context.ChangeTracker.LazyLoadingEnabled = false;
                result = context.Set<T>().ToList();
            }
            return result;
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public IEnumerable<T> GetAllv1()
        {
            return context.Set<T>().AsEnumerable();
        }
        public IQueryable<T> GetAllv2()
        {
            return context.Set<T>();
        }
    }
}
