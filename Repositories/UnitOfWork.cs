using Entity;
namespace Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly DBContext _dbContext;
        public IRepositoryEmployee Employee { get; set; }

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            Employee = new RepositoryEmployee(dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
            
        }

        public void Dispose()
        {
            
            _dbContext.Dispose();
        }

        public void Clear()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
