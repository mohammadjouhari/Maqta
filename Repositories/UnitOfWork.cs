using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DBContext _dbContext { get; set; }
        public IRepositoryEmployee Employee { get; set; }
        public RepositoryEmployee Employee2 { get; set; }
        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            Employee = new RepositoryEmployee(dbContext);
            Employee2 = new RepositoryEmployee(dbContext);
        }
        public void Complete()
        {
            _dbContext.SaveChanges(); 
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Enable()
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled= true;
        }

        public void Clear()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
