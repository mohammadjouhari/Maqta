using Entity;

namespace Repositories
{
    public interface IUnitOfWork
    {
       DBContext _dbContext { get; set; }
       IRepositoryEmployee Employee { get; }
       RepositoryEmployee Employee2 { get; }
       void Complete();
       void Dispose();
       void Clear();

       void Enable();
    }
}
